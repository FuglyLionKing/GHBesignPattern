using System;
using System.Collections.Generic;
using System.Linq;
using GHBesignPattern.Model.Boards;
using GHBesignPattern.Model.Characters;

public class DjikstraAlgorithm
{
    public static IEnumerable<IZone> Run(ICharacter character, IZone endNode)
    {
        IZone startNode = character.Position;


        var nodesToExploreList = new Dictionary<IZone, NodeInformations>();

        nodesToExploreList.Add(startNode, new NodeInformations
        {
            CurrentNode = startNode,
            FromNode = null,
            ComputedCost = 0
        });

        
        var exploredNodesList = new Dictionary<IZone, NodeInformations>();

        
        while (nodesToExploreList.Count != 0)
        {
        
            IOrderedEnumerable<NodeInformations> orderedNodesInfos =
                nodesToExploreList.Values.OrderBy(kv => kv.ComputedCost);
            NodeInformations selectedNodeInfos = orderedNodesInfos.First();

        
            if (selectedNodeInfos.CurrentNode == endNode)
            {
                break;
            }

            exploredNodesList.Add(selectedNodeInfos.CurrentNode, selectedNodeInfos);
            UpdateNeighbours(selectedNodeInfos, nodesToExploreList, exploredNodesList, character);      
            nodesToExploreList.Remove(selectedNodeInfos.CurrentNode);
        }

        
        if (nodesToExploreList.ContainsKey(endNode))
        {
        
            NodeInformations endNodeInfo = nodesToExploreList[endNode];
       
            return GetInvertedPath(endNodeInfo).Reverse();
        }
        
        return null;
    }

  
    protected static IEnumerable<IZone> GetInvertedPath(NodeInformations nodeInfos)
    {
        do
        {
            yield return nodeInfos.CurrentNode;
            nodeInfos = nodeInfos.FromNode;
        } while (nodeInfos != null);
    }

    protected static void UpdateNeighbours(NodeInformations nodeInfos,
        Dictionary<IZone, NodeInformations> nodesToExplore,
        Dictionary<IZone, NodeInformations> exploredNodes, ICharacter character
        )
    {
    
        foreach (IAccess link in nodeInfos.CurrentNode.Accesses)
        {
            if (!exploredNodes.ContainsKey(link.Target))
            {
                if(link.Target.ToString().Equals("zone : 9, 9"))
                    Console.WriteLine("target end node");

                //TODO replace boolean by actual cost ?
                float updatedCost = (null == link.AccessRestricted || link.AccessRestricted(character) ? nodeInfos.ComputedCost + 1 : long.MaxValue);
                NodeInformations targetNodeInfos = null;
                //Si la target fait parti des nodes � explorer on r�cup�re ses info
                if (nodesToExplore.ContainsKey(link.Target))
                    targetNodeInfos = nodesToExplore[link.Target];

                else
                {
                    //sinon on la cr�er avec
                    targetNodeInfos =
                        new NodeInformations
                        {
                            CurrentNode = link.Target,
                            FromNode = null,
                            ComputedCost = int.MaxValue
                        };
                    nodesToExplore.Add(targetNodeInfos.CurrentNode, targetNodeInfos);
                }


                if (updatedCost < targetNodeInfos.ComputedCost)
                {
                    targetNodeInfos.ComputedCost = updatedCost;
                    targetNodeInfos.FromNode = nodeInfos;
                }
            }
        }
    }

    protected class NodeInformations
    {
        public IZone CurrentNode { get; set; }
        public NodeInformations FromNode { get; set; }
        public float ComputedCost { get; set; }
    }
}