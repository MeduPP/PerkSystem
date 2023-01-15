
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
                if (node is CommonNode)
                {
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
        }
    }
}
