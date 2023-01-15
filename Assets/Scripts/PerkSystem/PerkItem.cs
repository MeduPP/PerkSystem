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

    private Image _image;

    public static Action OnPerkStateChanged;

    private void Awake()
    {
        node = new CommonNode();
        _image = GetComponent<Image>();

    }
    private void Start()
    {
        SetLinkedNodes();
    }

    private void UpdateState()
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

    private void Update()
    {
        UpdateState();
    }

    public void TryUnlock()
    {
        if ((node as CommonNode).nodeState == NodeState.CanUnlock)
        {
            (node as CommonNode).nodeState = NodeState.Unlocked;
            _image.color = unlockedColor;
            OnPerkStateChanged?.Invoke();
        }
        Debug.Log((node as CommonNode).nodeState);
    }
}
