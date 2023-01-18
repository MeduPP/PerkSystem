using PerkSystem;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CommonPerkItem), typeof(Image))]
public class PerkItemUI : MonoBehaviour
{
    [SerializeField] private Color unlockedColor;
    [SerializeField] private Color canUnlockColor;
    [SerializeField] private Color lockedColor;

    private Image image;
    private CommonPerkItem perkItem;

    private void Awake()
    {
        image = GetComponent<Image>();
        perkItem = GetComponent<CommonPerkItem>();
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
