using UnityEngine;
public enum SkillType
{
    None,
    Float,
    Int
}

public enum SkillOpton
{
    None,
    SpeedUp,
    Sprint,
    SprintSpeedUp,
    Jump,
    Income
}

[CreateAssetMenu(menuName = "Skills/Skill")]
public class Skill : ScriptableObject
{
    public SkillOpton option = SkillOpton.None;
    public string description;
    public int cost;
    [HideInInspector]
    public SkillType type = SkillType.None;
}
