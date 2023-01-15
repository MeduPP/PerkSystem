using PerkSystem;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePerkItem : MonoBehaviour
{
    protected static LinkedList<BasePerkItem> _allPerks = new LinkedList<BasePerkItem>();
    public List<BasePerkItem> _linkedPerks = new List<BasePerkItem>();
    public Node node;

    protected BasePerkItem()
    {
        _allPerks.AddLast(this);
    }
        

    public void SetLinkedNodes()
    {
        List<Node> nodes = new List<Node>();

        foreach (var item in _linkedPerks)
        {
            nodes.Add(item.node);
            Debug.Log(item.node + " " + gameObject.name);
        }

        node.SetLinkedNodes(nodes);
    }

}
