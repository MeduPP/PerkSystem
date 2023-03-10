using System.Collections.Generic;

namespace PerkSystem
{
    public abstract class Node
    {
        protected List<Node> LinkedNodes = new List<Node>();

        public void SetLinkedNodes(List<Node> LinkedNodes)
        {
            this.LinkedNodes.AddRange(LinkedNodes);
        }
        
        public List<Node> GetLinkedNodes()
        {
            return LinkedNodes;
        }
    }
}

