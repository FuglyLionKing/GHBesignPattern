using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class DjikstraAlgorithm
{
    /// <summary>
    /// Une classe que nous allons utiliser pour stocker pour chaque noeud
    /// les informations nécessaires à l'algorithme de Djikstra
    /// </summary>
    protected class NodeInformations
    {
        public Node CurrentNode { get; set; }
        public NodeInformations FromNode { get; set; }
        public float ComputedCost { get; set; }
    }

    /// <summary>
    /// Convertit une grille booléenne (case vide et obtacles) en graphe orienté pondéré
    /// Exécute l'algorithme de djikstra sur le graphe orienté pondéré généré
    /// Convertit le chemin trouvé en succession de coordonnées sur la grille
    /// </summary>
    /// <param name="grid">La grille booléenne représentant l'environnement</param>
    /// <param name="startPosX">La coordonnée X de la position de départ</param>
    /// <param name="startPosY">La coordonnée Y de la position de départ</param>
    /// <param name="endPosX">La coordonnée X de la position d'arrivée</param>
    /// <param name="endPosY">La coordonnée Y de la position d'arrivée</param>
    /// <returns></returns>
    static public IEnumerable<Vector2> RunOn2DGrid(bool[][] grid, int startPosX, int startPosY, int endPosX, int endPosY)
    {
        // Pour plus d'efficacité, nous allons utiliser deux dictionnaires 
        // pour avoir une association parfaite entre un Noeud et une position
        var graphToGridMapping = new Dictionary<Node, Vector2>();
        var gridToGraphMapping = new Dictionary<Vector2, Node>();

        // Création de l'ensemble des noeuds (un noeud par case)
        for (int i = 0; i < grid.Length; i++)
        {
            var line = grid[i];

            for (int j = 0; j < line.Length; j++)
            {
                // Création du noeud associé à la position (i, j)
                var node = new Node()
                {
                    ID = i * grid.Length + j,
                };

                // Création de la position (i, j)
                var pos = new Vector2(i, j);

                // ajout du couple créé dans les deux structures
                graphToGridMapping.Add(node, pos);
                gridToGraphMapping.Add(pos, node);
            }
        }

        // Création des arcs pour chaque noeuds en fonction de la position de
        // la case sur la grille et selon les obstacles
        foreach (var pos in gridToGraphMapping.Keys)
        {
            // Création de la structure stockant les liens (au maximum de 4 si l'on ne peut)
            // se déplacer dans la grille qu'horizontalement et verticalement
            var linkList = new List<Link>(4);

            // Doit-on ajouter un arc vers la case supérieure ?
            if (pos.y < grid.Length - 1 && !grid[(int)pos.x][(int)pos.y + 1])
            {
                var link = new Link()
                {
                    Cost = 1,
                    Origin = gridToGraphMapping[pos],
                    Target = gridToGraphMapping[new Vector2(pos.x, pos.y + 1)]
                };
                linkList.Add(link);
            }

            // Doit-on ajouter un arc vers la case inférieure ?
            if (pos.y > 0 && !grid[(int)pos.x][(int)pos.y - 1])
            {
                var link = new Link()
                {
                    Cost = 1,
                    Origin = gridToGraphMapping[pos],
                    Target = gridToGraphMapping[new Vector2(pos.x, pos.y - 1)]
                };
                linkList.Add(link);
            }

            // Doit-on ajouter un arc vers la case de gauche ?
            if (pos.x < grid[(int)pos.y].Length - 1 && !grid[(int)pos.x + 1][(int)pos.y])
            {
                var link = new Link()
                {
                    Cost = 1,
                    Origin = gridToGraphMapping[pos],
                    Target = gridToGraphMapping[new Vector2(pos.x + 1, pos.y)]
                };
                linkList.Add(link);
            }

            // Doit-on ajouter un arc vers la case de droite ?
            if (pos.x > 0 && !grid[(int)pos.x - 1][(int)pos.y])
            {
                var link = new Link()
                {
                    Cost = 1,
                    Origin = gridToGraphMapping[pos],
                    Target = gridToGraphMapping[new Vector2(pos.x - 1, pos.y)]
                };
                linkList.Add(link);
            }

            // Récupération du neoud
            var node = gridToGraphMapping[pos];

            // Initialisation des liens sous forme de tableau pour plus d'efficacité
            node.Links = linkList.ToArray();
        }

        // Lancement de l'algorithme de Djiikstra sur le graphe pondéré orienté associé
        var result = Run(graphToGridMapping

            // On n'ajoute que les noeuds correspondant à des cases qui ne sont pas des obstacles
            .Where((kv1) => !grid[(int)kv1.Value.x][(int)kv1.Value.y])
            .Select((kv2) => kv2.Key)
            ,
            gridToGraphMapping[new Vector2(startPosX, startPosY)],
            gridToGraphMapping[new Vector2(endPosX, endPosY)]);


        // On renvoie l'ensemble des positions du chemins optimal ou null si aucun n'a été trouvé
        return (result != null) ? result.Select((node2) => graphToGridMapping[node2]) : null;
    }

    /// <summary>
    /// Exécute l'algorithme de Djikstra sur un graphe quelconque composé de noeuds (Node) et d'arcs (Link)
    /// </summary>
    /// <param name="graph">L'ensemble des noeuds du graphe</param>
    /// <param name="startNode">Le noeud de départ</param>
    /// <param name="endNode">Le noeud d'arrivée</param>
    /// <returns></returns>
    static public IEnumerable<Node> Run(IEnumerable<Node> graph, Node startNode, Node endNode)
    {
        // Initialisation de la liste des noeuds à explorer 
        // (on prend le choix ici de la construire progressivement et de ne pas rajouter tous les noeuds d'un coup)
        var nodesToExploreList = new Dictionary<Node, NodeInformations>(graph.Count());

        // Ajout à la liste des noeuds à explorer du noeud de départ (et étiquetage à zéro de ce dernier)
        nodesToExploreList.Add(startNode, new NodeInformations()
        {
            CurrentNode = startNode,
            FromNode = null,
            ComputedCost = 0
        });

        // Initialisation de la liste des noeuds explorés
        var exploredNodesList = new Dictionary<Node, NodeInformations>(graph.Count());

        // Itération successives de l'algorithme
        while (true)
        {
            // Condition de sortie 1 : si il n'y a plus de noeuds à explorer
            if (nodesToExploreList.Count == 0)
            {
                nodesToExploreList = null;
                return null;
            }

            // Sélection du noeud de coût minimum parmi ceux à explorer
            var orderedNodesInfos = nodesToExploreList.Values.OrderBy((kv) => kv.ComputedCost);
            var selectedNodeInfos = orderedNodesInfos.First();

            // Condition de sortie 2 : si le noeud à explorer est le noeud d'arriver
            if (selectedNodeInfos.CurrentNode == endNode)
            {
                break;
            }

            // Ajout du noeud sélectionné à la liste des noeuds explorés
            exploredNodesList.Add(selectedNodeInfos.CurrentNode, selectedNodeInfos);

            // Mise à jour des poids des noeuds voisins au noeud sélectionné et ajout de ces derniers
            // à la liste des noeuds à explorer s'ils n'y étaient pas déjà.
            UpdateNeighbours(selectedNodeInfos, nodesToExploreList, exploredNodesList);

            // On retire de la liste des noeuds à explorer le noeud sélectionné et exploré
            nodesToExploreList.Remove(selectedNodeInfos.CurrentNode);
        }

        // Si le noeud d'arrivée a été trouvé
        if (nodesToExploreList.ContainsKey(endNode))
        {
            // Récupération des informations du noeud d'arrivée
            var endNodeInfo = nodesToExploreList[endNode];

            // Pour faciliter la vie du GC
            nodesToExploreList = null;
            exploredNodesList = null;

            // On renvoie le chemin trouvé (du noeud de départ au noeud d'arrivée)
            return GetInvertedPath(endNodeInfo).Reverse();
        }
        else
        {
            // Aucun chemin n'a été trouvé
            return null;
        }
    }

    /// <summary>
    /// Récupère le chemin de coût minimum à partir d'un noeud
    /// vers le noeud de départ
    /// </summary>
    /// <param name="nodeInfos"></param>
    /// <returns></returns>
    static protected IEnumerable<Node> GetInvertedPath(NodeInformations nodeInfos)
    {
        do
        {
            yield return nodeInfos.CurrentNode;
            nodeInfos = nodeInfos.FromNode;
        }
        while (nodeInfos != null);
    }

    /// <summary>
    /// Mets à jour les voisins du noeud passé en paramètre 
    /// </summary>
    /// <param name="nodeInfos"></param>
    /// <param name="nodesToExplore"></param>
    /// <param name="exploredNodes"></param>
    static protected void UpdateNeighbours(NodeInformations nodeInfos,
        Dictionary<Node, NodeInformations> nodesToExplore,
        Dictionary<Node, NodeInformations> exploredNodes
        )
    {
        // Pour chacun des arcs sortant du noeud
        foreach (var link in nodeInfos.CurrentNode.Links)
        {
            // On exclut les noeuds déjà explorés
            if (!exploredNodes.ContainsKey(link.Target))
            {
                // On calcule le coût pour atteindre le noeud voisin 
                // en passant par le noeud sélectionné
                var updatedCost = (nodeInfos.ComputedCost + link.Cost);
                NodeInformations targetNodeInfos = null;
                if (nodesToExplore.ContainsKey(link.Target))
                    targetNodeInfos = nodesToExplore[link.Target];

                // Si le noeud voisin n'a pas été encore 
                // ajouté à la liste des noeuds à explorer
                else
                {
                    targetNodeInfos =
                        new NodeInformations()
                        {
                            CurrentNode = link.Target,
                            FromNode = null,
                            ComputedCost = int.MaxValue
                        };
                    nodesToExplore.Add(targetNodeInfos.CurrentNode, targetNodeInfos);
                }

                // Si le nouveau coût est inférieur au coût courant du noeud voisin, on
                // met à jour.
                if (updatedCost < targetNodeInfos.ComputedCost)
                {
                    targetNodeInfos.ComputedCost = updatedCost;
                    targetNodeInfos.FromNode = nodeInfos;
                }
            }
        }
    }
}
