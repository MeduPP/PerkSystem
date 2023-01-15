namespace PerkSystem
{
    public class BaseNode : Node
    {
        public void CheckNodesState()
        {
            //by default, we can unlock neighbor nodes of the base node
            foreach (var node in LinkedNodes)
            {
                if (node is CommonNode)
                {
                    //if the neighbor is already unlocked, checking its neighbor
                    if ((node as CommonNode).nodeState == NodeState.Unlocked)
                    {
                        (node as CommonNode).NeighborsCheck();
                        continue;
                    }
                    else
                    {
                        (node as CommonNode).nodeState = NodeState.CanUnlock;
                    }
                }
            }
            visitedNodes.Clear();
        }
    }
}

