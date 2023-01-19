using PerkSystem;
using System;
using UnityEngine;

public class CommonPerkItem : PerkItem
{
    public Skill skill;

    public static Action OnPerkStateChanged;

    public override void Awake()
    {
        node = new CommonNode();
        base.Awake();
    }

    public void TryUnlock()
    {
        CommonNode node = this.node as CommonNode;

        if (node.nodeState == NodeState.CanUnlock)
        {
            node.UnlockPerk();
            OnPerkStateChanged?.Invoke();
            return;
        }

        if (node.nodeState == NodeState.Unlocked)
        {
            node.TryForget();
            OnPerkStateChanged?.Invoke();
            return;
        }
    }
}
