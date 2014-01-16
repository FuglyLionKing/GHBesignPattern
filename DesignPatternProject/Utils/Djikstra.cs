using System.Linq;
using System.Collections;
using System.Collections.Generic;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Characters;

public class DjikstraAlgorithm
{
    /// <summary>
    /// Une classe que nous allons utiliser pour stocker pour chaque noeud
    /// les informations n�cessaires � l'algorithme de Djikstra
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

        // Ajout � la liste des noeuds � explorer du noeud de d�part (et �tiquetage � z�ro de ce dernier)
        nodesToExploreList.Add(startNode, new NodeInformations()
        {
            CurrentNode = startNode,
            FromNode = null,
            ComputedCost = 0
        });

        // Initialisation de la liste des noeuds explor�s
        var exploredNodesList = new Dictionary<IZone, NodeInformations>();

        // It�ration successives de l'algorithme
        while (true)
        {
            // Condition de sortie 1 : si il n'y a plus de noeuds � explorer
            if (nodesToExploreList.Count == 0)
            {
                nodesToExploreList = null;
                return null;
            }

            // S�lection du noeud de co�t minimum parmi ceux � explorer
            var orderedNodesInfos = nodesToExploreList.Values.OrderBy((kv) => kv.ComputedCost);
            var selectedNodeInfos = orderedNodesInfos.First();

            // Condition de sortie 2 : si le noeud � explorer est le noeud d'arriver
            if (selectedNodeInfos.CurrentNode == endNode)
            {
                break;
            }

            // Ajout du noeud s�lectionn� � la liste des noeuds explor�s
            exploredNodesList.Add(selectedNodeInfos.CurrentNode, selectedNodeInfos);

            // Mise � jour des poids des noeuds voisins au noeud s�lectionn� et ajout de ces derniers
            // � la liste des noeuds � explorer s'ils n'y �taient pas d�j�.
            UpdateNeighbours(selectedNodeInfos, nodesToExploreList, exploredNodesList, character);

            // On retire de la liste des noeuds � explorer le noeud s�lectionn� et explor�
            nodesToExploreList.Remove(selectedNodeInfos.CurrentNode);
        }

        // Si le noeud d'arriv�e a �t� trouv�
        if (nodesToExploreList.ContainsKey(endNode))
        {
            // R�cup�ration des informations du noeud d'arriv�e
            var endNodeInfo = nodesToExploreList[endNode];

            // Pour faciliter la vie du GC
            nodesToExploreList = null;
            exploredNodesList = null;

            // On renvoie le chemin trouv� (du noeud de d�part au noeud d'arriv�e)
            return GetInvertedPath(endNodeInfo).Reverse();
        }
        else
        {
            // Aucun chemin n'a �t� trouv�
            return null;
        }
    }

    /// <summary>
    /// R�cup�re le chemin de co�t minimum � partir d'un noeud
    /// vers le noeud de d�part
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
    /// Mets � jour les voisins du noeud pass� en param�tre 
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
            // On exclut les noeuds d�j� explor�s
            if (!exploredNodes.ContainsKey(link.Target))
            {
                // On calcule le co�t pour atteindre le noeud voisin 
                // en passant par le noeud s�lectionn�

                //TODO replace boolean by actual cost ?
                var updatedCost = (link.AccessRestricted(character) ? nodeInfos.ComputedCost + 1 : long.MaxValue);
                NodeInformations targetNodeInfos = null;
                if (nodesToExplore.ContainsKey(link.Target))
                    targetNodeInfos = nodesToExplore[link.Target];

                // Si le noeud voisin n'a pas �t� encore 
                // ajout� � la liste des noeuds � explorer
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

                // Si le nouveau co�t est inf�rieur au co�t courant du noeud voisin, on
                // met � jour.
                if (updatedCost < targetNodeInfos.ComputedCost)
                {
                    targetNodeInfos.ComputedCost = updatedCost;
                    targetNodeInfos.FromNode = nodeInfos;
                }
            }
        }
    }
}
