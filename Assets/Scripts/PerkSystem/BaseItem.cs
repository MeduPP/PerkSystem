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
        SetLinkedNodes();
        //Set all links from view to system
        foreach(var perk in _allPerks)
        {
            perk.SetLinkedNodes();
            Debug.Log("1");
        }

        (node as BaseNode).SetNeighboorState();
        CommonPerkItem.OnPerkStateChanged?.Invoke();
    }
}
