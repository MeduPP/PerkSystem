using PerkSystem;
using UnityEngine;

public class BaseItem : PerkItem
{
    public override void Awake()
    {
        node = new BaseNode();
        base.Awake();
    }

    private void Start()
    {
        BaseNode node = this.node as BaseNode;

        SetLinkedNodes();

        //Set all links for node system
        foreach(var perk in allPerks)
        {
            perk.SetLinkedNodes();
        }

        //Set neighboors of base node available to unlock
        node.SetNeighboorState();

        CommonPerkItem.OnPerkStateChanged?.Invoke();
    }
}
