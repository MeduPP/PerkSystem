
using System.Collections.Generic;

public enum NodeState
{
    Unlocked,
    Locked,
    CanUnlock,
    CanForget
}

namespace PerkSystem
{
    public class CommonNode : Node
    {
        public NodeState nodeState = NodeState.Locked;

        public void NeighborsCheck()
        {
            visitedNodes.AddLast(this);

            foreach (var node in LinkedNodes)
            {
                if (!(node is CommonNode))
                    continue;

                if (visitedNodes.Contains(node))
                    continue;

                if ((node as CommonNode).nodeState == NodeState.Locked)
                {
                    (node as CommonNode).nodeState = NodeState.CanUnlock;
                    continue;
                }

                if ((node as CommonNode).nodeState == NodeState.Unlocked)
                {
                    (node as CommonNode).NeighborsCheck();
                }
            }
        }

        public void TryForget()
        {
            if (CanForget())
            {
                nodeState = NodeState.CanUnlock;

                foreach (var node in LinkedNodes)
                {
                    if (!(node is CommonNode))
                        continue;

                    if ((node as CommonNode).nodeState == NodeState.CanUnlock)
                    {
                        (node as CommonNode).nodeState = NodeState.Locked;
                    }
                }
            }
        }

        public bool CanForget()
        {
            foreach (var node in LinkedNodes)
            {
                if (!(node is CommonNode))
                    continue;

                if ((node as CommonNode).nodeState == NodeState.Unlocked)
                {
                    List<Node> visitedNodes = new List<Node>();
                    visitedNodes.Add(this);
                    if(!(node as CommonNode).CanReachRootNode(visitedNodes))
                        return false;
                }
            }
            return true;
        }

        private bool CanReachRootNode(List<Node> visitedNodes)
        {
            visitedNodes.Add(this);

            foreach (var node in LinkedNodes)
            {

                if (node is BaseNode)
                    return true;

                if (!(node is CommonNode) || visitedNodes.Contains(node))
                    continue;

                if ((node as CommonNode).nodeState == NodeState.Unlocked)
                    if((node as CommonNode).CanReachRootNode(visitedNodes))
                        return true;
            }
            return false;
        }
    }
}
