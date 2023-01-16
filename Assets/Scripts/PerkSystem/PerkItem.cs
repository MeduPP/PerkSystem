using PerkSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PerkItem : BasePerkItem
{
    [SerializeField] private Color unlockedColor;
    [SerializeField] private Color canUnlockColor;
    [SerializeField] private Color lockedColor;

    public static Action OnPerkStateChanged;

    private Image _image;

    public override void Awake()
    {
        base.Awake();
        _image = GetComponent<Image>();
        node = new CommonNode();
    }

    private void Start()
    {
        List<Node> nodes = new List<Node>();
        _linkedPerks.ForEach(
            (item) =>
            {
                nodes.Add(item.node);
            }
            );
        (node as CommonNode).SetLinkedNodes(nodes);
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
            case (NodeState.CanForget):
                break;
        }
    }

    public void TryUnlock()
    {
        if ((node as CommonNode).nodeState == NodeState.CanUnlock)
        {
            (node as CommonNode).nodeState = NodeState.Unlocked;
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
