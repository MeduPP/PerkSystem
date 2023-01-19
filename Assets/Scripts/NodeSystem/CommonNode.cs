using System.Collections.Generic;

public enum NodeState
{
    Unlocked,
    Locked,
    CanUnlock
}

namespace PerkSystem
{
    public class CommonNode : Node
    {
        private NodeState _nodeState = NodeState.Locked;
        public NodeState nodeState { get { return _nodeState; } private set { _nodeState = value; } }

        public void UnlockPerk()
        {
            if (!(nodeState == NodeState.CanUnlock))
                return;

            nodeState = NodeState.Unlocked;

            foreach (var node in LinkedNodes)
            {
                if(node is CommonNode)
                {
                    if(!((node as CommonNode).nodeState == NodeState.Unlocked))
                        (node as CommonNode).nodeState = NodeState.CanUnlock;

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
                        (node as CommonNode).SetNeighborsUnlockable();
                    }
                }
            }
        }

        public void SetNeighborsUnlockable()
        {
            foreach (var node in LinkedNodes)
            {
                if (node is BaseNode)
                {
                    nodeState = NodeState.CanUnlock;
                    return;
                }

                if (!(node is CommonNode))
                    continue;

                if ((node as CommonNode).nodeState == NodeState.Unlocked)
                {
                    nodeState = NodeState.CanUnlock;
                    return;
                }

                nodeState = NodeState.Locked;
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
                    if (!(node as CommonNode).CanReachRootNode(visitedNodes))
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
                    if ((node as CommonNode).CanReachRootNode(visitedNodes))
                        return true;
            }
            return false;
        }
    }
}
