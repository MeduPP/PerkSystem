using PerkSystem;
using UnityEngine;

public class RootItem : PerkItem
{
    public override void Awake()
    {
        node = new RootNode();
        base.Awake();
    }

    private void Start()
    {
        RootNode node = this.node as RootNode;

        SetLinkedNodes();

        //Set all links for node system
        foreach(var perk in allPerks)
        {
            perk.SetLinkedNodes();
        }

        //Set neighboors of root node available to unlock
        node.SetNeighborsState();

        CommonPerkItem.OnPerkStateChanged?.Invoke();
    }
}
