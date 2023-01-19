using PerkSystem;
using System.Collections.Generic;
using UnityEngine;

public class PerkController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] SkillUnlockUI skillUnlockUI;
    [SerializeField] Player player;

    //cache all existing perk items
    private LinkedList<PerkItem> perkItems = PerkItem.allPerks;

    private void OnPerksStateChanged()
    {
        if (playerController == null || player == null)
        {
            Debug.LogError("All references must be setted");
            return;
        }

        //Set defoult states for all boosts
        player.ResetBoosts();
        playerController.ResetBoosts();

        foreach (var perk in perkItems)
        {
            if (perk is CommonPerkItem)
            {
                Skill skill = (perk as CommonPerkItem).skill;
                CommonNode node = (perk as CommonPerkItem).node as CommonNode;

                //Seting actual skill values
                if (node.nodeState == NodeState.Unlocked)
                {
                    switch (skill.option)
                    {
                        case SkillOpton.Income:
                            player.IncomeValue += (skill.type == SkillType.Int) ? (skill as IntSkill).boostValue : 0;
                            break;
                        case SkillOpton.SprintSpeedUp:
                            playerController.SprintSpeedBoost = (skill.type == SkillType.Float) ? (skill as FloatSkill).boostValue : 0;
                            break;
                        case SkillOpton.SpeedUp:
                            playerController.SpeedBoost = (skill.type == SkillType.Float) ? (skill as FloatSkill).boostValue : 0;
                            break;
                        case SkillOpton.Sprint:
                            playerController.canSprint = true;
                            break;
                        case SkillOpton.Jump:
                            playerController.canJump = true;
                            break;
                    }
                }
            }
        }
    }

    private void TryForgetSkill(CommonPerkItem perkItem)
    {
        if (perkItem.TryForget())
        {
            player.AddPoints(perkItem.skill.cost);
            skillUnlockUI.Refrash();
        }
    }
    private void TryUnlockSkill(CommonPerkItem perkItem)
    {
        if (perkItem.CanUnlock() && player.TrySpendPoints(perkItem.skill.cost))
        {
            perkItem.TryUnlock();
            skillUnlockUI.Refrash();
        }
    }
    
    //if user click on any perk item
    private void PerkChoosed(CommonPerkItem perkItem)
    {
        //fill info into form
        skillUnlockUI?.SetSkillInfo(perkItem, player);
    }

    private void OnEnable()
    {
        CommonPerkItem.OnPerkStateChanged += OnPerksStateChanged;
        PerkItemUI.OnPerkChoosed += PerkChoosed;
        skillUnlockUI.OnTryForget += TryForgetSkill;
        skillUnlockUI.OnTryUnlock += TryUnlockSkill;
    }

    private void OnDisable()
    {
        CommonPerkItem.OnPerkStateChanged -= OnPerksStateChanged;
        PerkItemUI.OnPerkChoosed -= PerkChoosed;
        skillUnlockUI.OnTryForget -= TryForgetSkill;
        skillUnlockUI.OnTryUnlock -= TryUnlockSkill;
    }
}
