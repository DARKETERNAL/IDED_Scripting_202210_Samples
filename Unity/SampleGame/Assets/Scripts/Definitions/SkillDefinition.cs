using UnityEngine;

[CreateAssetMenu(fileName = "NewSkillDefinition", menuName = "ScriptableObjects/Create Skill Definition")]
public class SkillDefinition : ScriptableObject
{
    public enum ESkillType
    {
        AttackSkill,
        DebuffSkill,
        HealSkill,
    }

    [SerializeField]
    private ESkillType skillType;

    [SerializeField]
    private string name;

    [SerializeField]
    private float effectValue;

    [SerializeField]
    private EParameterType parameterType;

    [SerializeField]
    private float effectChance = 1F;

    public string Name { get => name; }
    public float EffectValue { get => effectValue; }
    public ESkillType SkillType { get => skillType; }
    public EParameterType ParameterType { get => parameterType; }
    public float EffectChance { get => effectChance; }
}