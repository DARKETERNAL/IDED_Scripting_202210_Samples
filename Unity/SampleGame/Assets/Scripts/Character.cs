public class Character // Nouns
{
    private int baseHp; // Adjectives
    private float baseAtk;
    private float baseDef;
    private float baseSpec;

    private float atkFactor = 1F;
    private float defFactor = 1F;
    private float specFactor = 1F;

    public int HP
    {
        get => baseHp;
        set => baseHp = value;
    }

    public float Atk
    {
        get => baseAtk * atkFactor;
        set => baseAtk = value;
    }

    public float Def
    {
        get => baseDef * defFactor;
        set => baseDef = value;
    }

    public float Spec
    {
        get => baseSpec * specFactor;
        set => baseSpec = value;
    }

    public string Name { get; private set; }

    public Character()
    {
        Name = "Char000";
        Atk = 0F;
        Def = 0F;
        Spec = 0F;
    }

    public Character(string name, float atk, float def, float spec)
    {
        Name = name;
        Atk = atk;
        Def = def;
        Spec = spec;
    }

    public void PerformAttack(Character target) // Actions
    {
        // Attack target character
    }

    public void BlockAttack()
    {
    }

    public void UseItem(Item target) // implicit cast
    {
        if (target is HealthItem)
        {
            HP += (int)target.EffectValue; // explicit cast
        }
        else if (target is BuffItem)
        {
            BuffItem targetBuffItem = target as BuffItem; // explicit cast

            if (targetBuffItem != null)
            {
                switch (targetBuffItem.TargetParameter)
                {
                    case EParameterType.ATK:
                        atkFactor = targetBuffItem.EffectValue;
                        break;

                    case EParameterType.DEF:
                        defFactor = targetBuffItem.EffectValue;
                        break;

                    case EParameterType.SPEC:
                        specFactor = targetBuffItem.EffectValue;
                        break;

                    default:
                        break;
                }
            }
        }
    }

    public void PermformSkill(Skill target)
    {
        if (target is HealSkill)
        {
            HP += (int)target.EffectValue;
        }
    }
}