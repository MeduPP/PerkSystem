using PerkSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CommonPerkItem : PerkItem
{
    [SerializeField] private Color unlockedColor;
    [SerializeField] private Color canUnlockColor;
    [SerializeField] private Color lockedColor;

    public static Action OnPerkStateChanged;

    private Image _image;

    public override void Awake()
    {
        node = new CommonNode();
        _image = GetComponent<Image>();
        base.Awake();
    }

    public void UpdateState()
    {
        switch ((node as CommonNode).nodeState)
        {
            case (NodeState.Locked):
                _image.color = lockedColor;
                break;
            case (NodeState.Unlocked):
                _image.color = unlockedColor;
                break;
            case (NodeState.CanUnlock):
                _image.color = canUnlockColor;
                break;
        }
    }

    public void TryUnlock()
    {
        if ((node as CommonNode).nodeState == NodeState.CanUnlock)
        {
            (node as CommonNode).UnlockPerk();
            _image.color = unlockedColor;
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
