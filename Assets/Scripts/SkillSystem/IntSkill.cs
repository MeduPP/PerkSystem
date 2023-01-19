
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/IntSkill")]
public class IntSkill : Skill
{
    public IntSkill()
    {
        type= SkillType.Int;
    }

    public int boostValue;
}
