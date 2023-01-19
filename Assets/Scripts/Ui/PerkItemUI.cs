using PerkSystem;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CommonPerkItem), typeof(Image), typeof(Button))]
public class PerkItemUI : MonoBehaviour
{
    [SerializeField] private Color unlockedColor;
    [SerializeField] private Color canUnlockColor;
    [SerializeField] private Color lockedColor;

    //Called when the user presses the perk button 
    public static Action<CommonPerkItem> OnPerkChoosed;

    private Button button;
    private Image image;
    private CommonPerkItem perkItem;

    private void Awake()
    {
        button = GetComponent<Button>();    
        image = GetComponent<Image>();
        perkItem = GetComponent<CommonPerkItem>();

        button.onClick.AddListener(PerkChoosed);
    }

    public void PerkChoosed()
    {
        OnPerkChoosed?.Invoke(perkItem);
    }

    public void UpdateState()
    {
        switch ((perkItem.node as CommonNode).nodeState)
        {
            case (NodeState.Locked):
                image.color = lockedColor;
                break;
            case (NodeState.Unlocked):
                image.color = unlockedColor;
                break;
            case (NodeState.CanUnlock):
                image.color = canUnlockColor;
                break;
        }
    }

    private void OnEnable()
    {
        CommonPerkItem.OnPerkStateChanged += UpdateState;
    }

    private void OnDisable()
    {
        CommonPerkItem.OnPerkStateChanged -= UpdateState;
    }
}
