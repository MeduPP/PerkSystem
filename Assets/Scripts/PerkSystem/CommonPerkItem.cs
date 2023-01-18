using PerkSystem;
using System;

public class CommonPerkItem : PerkItem
{
    public static Action OnPerkStateChanged;

    public override void Awake()
    {
        node = new CommonNode();
        base.Awake();
    }

    public void TryUnlock()
    {
        if ((node as CommonNode).nodeState == NodeState.CanUnlock)
        {
            (node as CommonNode).UnlockPerk();
            OnPerkStateChanged?.Invoke();
            return;
        }

        if ((node as CommonNode).nodeState == NodeState.Unlocked)
        {
            (node as CommonNode).TryForget();
            OnPerkStateChanged?.Invoke();
            return;
        }
    }
}
