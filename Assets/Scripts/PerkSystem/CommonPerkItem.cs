using PerkSystem;
using System;
using UnityEngine;

public class CommonPerkItem : PerkItem
{
    public Skill skill;
    //Called when perk state updates 
    public static Action OnPerkStateChanged;

    public NodeState State { get { return (node as CommonNode).nodeState; } } 

    public override void Awake()
    {
        node = new CommonNode();
        base.Awake();
    }

    public bool CanUnlock()
    {
        CommonNode node = this.node as CommonNode;
        return node.nodeState == NodeState.CanUnlock;
    }

    public bool TryUnlock()
    {
        CommonNode node = this.node as CommonNode;

        if (node.nodeState == NodeState.CanUnlock)
        {
            node.UnlockPerk();
            OnPerkStateChanged?.Invoke();
            return true;
        }
        return false;
    }

    public bool CanForget()
    {
        return (node as CommonNode).CanForget();
    }

    public bool TryForget()
    {
        CommonNode node = this.node as CommonNode;

        if (node.nodeState == NodeState.Unlocked)
        {
            bool result = node.TryForget();
            if(result) OnPerkStateChanged?.Invoke();
            return result;
        }
        return false;
    }
}
