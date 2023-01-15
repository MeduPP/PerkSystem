using PerkSystem;
using UnityEngine;

public class BaseItem : BasePerkItem
{
    private void Awake()
    {
        node = new BaseNode();
        Debug.Log(_allPerks.Count + "  !!!");
    }

    private void Start()
    {
        SetLinkedNodes();
    }

    [ContextMenu("CheckState")]
    private void CheckNodeState()
    {
        (node as BaseNode).CheckNodesState();
        Debug.Log("Triggered");
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
