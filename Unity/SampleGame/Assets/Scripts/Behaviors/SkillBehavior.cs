using UnityEngine;

public class SkillBehavior : MonoBehaviour
{
    [SerializeField]
    private SkillDefinition skillDefinition;

    private Skill skill;

    // Start is called before the first frame update
    private void Start()
    {
        switch (skillDefinition.SkillType)
        {
            case SkillDefinition.ESkillType.AttackSkill:
                skill = new AttackSkill(skillDefinition.Name, skillDefinition.EffectValue);
                break;

            case SkillDefinition.ESkillType.DebuffSkill:
                skill = new DebuffSkill(skillDefinition.Name, skillDefinition.EffectValue, skillDefinition.ParameterType, skillDefinition.EffectChance);
                break;

            case SkillDefinition.ESkillType.HealSkill:
                skill = new HealSkill(skillDefinition.Name, skillDefinition.EffectValue);
                break;
        }
    }
}