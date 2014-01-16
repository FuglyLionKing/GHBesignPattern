using System.Linq;
using System.Collections;
using System.Collections.Generic;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Characters;

public class DjikstraAlgorithm
{
    /// <summary>
    /// Une classe que nous allons utiliser pour stocker pour chaque noeud
    /// les informations nécessaires à l'algorithme de Djikstra
    /// </summary>
    protected class NodeInformations
    {
        public IZone CurrentNode { get; set; }
        public NodeInformations FromNode { get; set; }
        public float ComputedCost { get; set; }
    }


    static public IEnumerable<IZone> Run( ICharacter character, IZone endNode)
    {

        IZone startNode = character.Position;


       
        var nodesToExploreList = new Dictionary<IZone, NodeInformations>();

        // Ajout à la liste des noeuds à explorer du noeud de départ (et étiquetage à zéro de ce dernier)
        nodesToExploreList.Add(startNode, new NodeInformations()
        {
            CurrentNode = startNode,
            FromNode = null,
            ComputedCost = 0
        });

        // Initialisation de la liste des noeuds explorés
        var exploredNodesList = new Dictionary<IZone, NodeInformations>();

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
            UpdateNeighbours(selectedNodeInfos, nodesToExploreList, exploredNodesList, character);

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
    static protected IEnumerable<IZone> GetInvertedPath(NodeInformations nodeInfos)
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
        Dictionary<IZone, NodeInformations> nodesToExplore,
        Dictionary<IZone, NodeInformations> exploredNodes, ICharacter character
        )
    {
        // Pour chacun des arcs sortant du noeud
        foreach (var link in nodeInfos.CurrentNode.Accesses)
        {
            // On exclut les noeuds déjà explorés
            if (!exploredNodes.ContainsKey(link.Target))
            {
                // On calcule le coût pour atteindre le noeud voisin 
                // en passant par le noeud sélectionné

                //TODO replace boolean by actual cost ?
                var updatedCost = (link.AccessRestricted(character) ? nodeInfos.ComputedCost + 1 : long.MaxValue);
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
