using PerkSystem;
using UnityEngine;

public class BaseItem : BasePerkItem
{
    public override void Awake()
    {
        base.Awake();
        node = new BaseNode();
    }

    private void Start()
    {
        //Set all links from view to system
        foreach(var perk in _allPerks)
        {
            perk.SetLinkedNodes();
        }

        CheckNodeState();

        //update view state
        foreach(var perk in _allPerks)
        {
            if (perk is PerkItem)
                (perk as PerkItem).UpdateState();
        }
    }

    [ContextMenu("CheckState")]
    private void CheckNodeState()
    {
        (node as BaseNode).CheckNodesState();

        foreach (var perk in _allPerks)
        {
            if (perk is PerkItem)
                (perk as PerkItem).UpdateState();
        }
    }


    private void OnEnable()
    {
        PerkItem.OnPerkStateChanged += CheckNodeState;
    }
    private void OnDisable()
    {
        PerkItem.OnPerkStateChanged -= CheckNodeState;
    }
}
