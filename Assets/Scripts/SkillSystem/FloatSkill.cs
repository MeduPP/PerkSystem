using UnityEngine;

[CreateAssetMenu(menuName = "Skills/FloatSkill")]
public class FloatSkill : Skill
{
    public float boostValue;
    public FloatSkill()
    {
        type = SkillType.Float;
    }
}
