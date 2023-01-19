namespace PerkSystem
{
    public class RootNode : Node
    {
        public void SetNeighborsState()
        {
            //by default, we can unlock neighbor nodes of the base node
            foreach (var node in LinkedNodes)
            {
                if (!(node is CommonNode))
                    continue;

                //if the neighbor is already unlocked, checking its neighbor
                (node as CommonNode).SetNeighborsUnlockable();
            }
        }
    }
}

