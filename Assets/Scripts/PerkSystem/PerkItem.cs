using PerkSystem;
using System.Collections.Generic;
using UnityEngine;

public abstract class PerkItem : MonoBehaviour
{
    public static LinkedList<PerkItem> allPerks = new LinkedList<PerkItem>();
    public List<PerkItem> linkedPerks = new List<PerkItem>();
    public Node node;

    public virtual void Awake()
    {
        allPerks.AddLast(this);
    }
        
    public void SetLinkedNodes()
    {
        List<Node> nodes = new List<Node>();

        foreach (var item in linkedPerks)
        {
            nodes.Add(item.node);
        }

        node.SetLinkedNodes(nodes);
    }
}
