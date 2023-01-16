using PerkSystem;
using System.Collections.Generic;
using UnityEngine;

public abstract class PerkItem : MonoBehaviour
{
    protected static LinkedList<PerkItem> _allPerks = new LinkedList<PerkItem>();
    public List<PerkItem> _linkedPerks = new List<PerkItem>();
    public Node node;

    public virtual void Awake()
    {
        _allPerks.AddLast(this);
    }
        
    public void SetLinkedNodes()
    {
        List<Node> nodes = new List<Node>();

        foreach (var item in _linkedPerks)
        {
            nodes.Add(item.node);
        }

        node.SetLinkedNodes(nodes);
    }
}
