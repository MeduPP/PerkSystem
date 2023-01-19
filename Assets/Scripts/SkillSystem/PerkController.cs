using PerkSystem;
using System.Collections.Generic;
using UnityEngine;

public class PerkController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] Player player;

    private LinkedList<PerkItem> perkItems = PerkItem.allPerks;

    private void OnPerksStateChanged()
    {
        if (playerController == null || player == null)
        {
            Debug.LogError("All reference must be seted");
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

    private void OnEnable()
    {
        CommonPerkItem.OnPerkStateChanged += OnPerksStateChanged;
    }

    private void OnDisable()
    {
        CommonPerkItem.OnPerkStateChanged -= OnPerksStateChanged;
    }
}
