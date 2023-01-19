using PerkSystem;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillUnlockUI : MonoBehaviour
{
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Button unlockBtn;
    [SerializeField] private TMP_Text buttonText;

    public Action<CommonPerkItem> OnTryUnlock;
    public Action<CommonPerkItem> OnTryForget;

    private CommonPerkItem currentPerkItem;
    private Player currentPlayer;

    //Set the ui depends on the perk state
    public void SetSkillInfo(CommonPerkItem perkItem, Player player)
    {
        currentPerkItem = perkItem;
        currentPlayer = player;

         gameObject.SetActive(true);

        descriptionText.text = perkItem.skill.description;
        costText.text = $"Cost: {perkItem.skill.cost}";
        unlockBtn.onClick.RemoveAllListeners();

        switch (perkItem.State)
        {
            case NodeState.Unlocked:
                unlockBtn.interactable = perkItem.CanForget();
                buttonText.text = "Forget";
                unlockBtn.onClick.AddListener(TryForget);
                break;
            case NodeState.CanUnlock:
                unlockBtn.interactable = player.Points >= perkItem.skill.cost;
                buttonText.text = "Unlock";
                unlockBtn.onClick.AddListener(TryUnlock);
                break;
            case NodeState.Locked:
                costText.text = $"Cost: {perkItem.skill.cost}";
                unlockBtn.interactable = false;
                buttonText.text = "Locked";
                break;
        }
    }

    public void TryForget()
    {
        OnTryForget?.Invoke(currentPerkItem);
    }

    public void TryUnlock()
    {
        OnTryUnlock?.Invoke(currentPerkItem);
    }


    public void Refrash()
    {
        SetSkillInfo(currentPerkItem, currentPlayer);
    }
}
