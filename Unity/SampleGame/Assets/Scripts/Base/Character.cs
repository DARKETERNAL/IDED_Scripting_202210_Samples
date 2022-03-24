using System;

[Serializable]
public class Character // Nouns
{
    private int baseHp; // Adjectives
    private float baseAtk;
    private float baseDef;
    private float baseSpec;

    private float atkFactor = 0F;
    private float defFactor = 0F;
    private float specFactor = 0F;

    private Character target;

    private IWeapon weapon;

    public int HP
    {
        get => baseHp;
        private set => baseHp = value;
    }

    public float Atk
    {
        get => baseAtk * (1 + atkFactor) + (weapon == null ? 0 : weapon.Atk);
        private set => baseAtk = value;
    }

    public float Def
    {
        get => baseDef * (1 + defFactor);
        private set => baseDef = value;
    }

    public float Spec
    {
        get => baseSpec * (1 + specFactor);
        private set => baseSpec = value;
    }

    public string Name { get; private set; }

    public Character()
    {
        Name = "Char000";
        HP = 0;
        Atk = 0F;
        Def = 0F;
        Spec = 0F;
    }

    public Character(string name, int hp, float atk, float def, float spec)
    {
        Name = name;
        HP = hp;
        Atk = atk;
        Def = def;
        Spec = spec;
    }

    public void EquipWeapon(IWeapon targetWeapon)
    {
        if (targetWeapon != null)
        {
            weapon = targetWeapon;
        }
    }

    public void PerformSpecialAttack()
    {
        //weapon?.PerformSpecialAttack(target);

        if (weapon != null)
        {
            weapon.PerformSpecialAttack(target);
        }
        else
        {
            PerformAttack();
        }
    }

    public void ApplyDamage(int delta)
    {
        ModifyHP(-delta);
    }

    public void ApplyHeal(int delta)
    {
        ModifyHP(delta);
    }

    public void ModifyParamFactor(EParameterType parameterType, float paramValue)
    {
        switch (parameterType)
        {
            case EParameterType.ATK:
                atkFactor = paramValue;
                break;

            case EParameterType.DEF:
                defFactor = paramValue;
                break;

            case EParameterType.SPEC:
                specFactor = paramValue;
                break;
        }
    }

    public void AssignTargetCharacter(Character character)
    {
        target = character;
    }

    public void PerformAttack() // Actions
    {
        target.ApplyDamage((int)Atk);
    }

    public void BlockAttack()
    {
        defFactor = 1F;
    }

    public void UseItem(Item item) // implicit cast
    {
        if (item is HealthItem)
        {
            //HP += (int)item.EffectValue; // explicit cast
            ApplyHeal((int)item.EffectValue);
        }
        else if (item is BuffItem)
        {
            ModifyParamFactor((item as BuffItem).TargetParameter, item.EffectValue);

            // Same as above

            //BuffItem buffItem = item as BuffItem; // explicit cast

            //if (buffItem != null)
            //{
            //    ModifyParamFactor(buffItem.TargetParameter, buffItem.EffectValue);
            //}
        }
    }

    public void PermformSkill(Skill skill)
    {
        if (skill is HealSkill)
        {
            ApplyHeal((int)skill.EffectValue);
        }
        else if (skill is AttackSkill)
        {
            target.ApplyDamage((int)skill.EffectValue);

            //target.ModifyHP(-(int)skill.EffectValue);
        }
        else if (skill is DebuffSkill)
        {
            DebuffSkill defuffSkill = skill as DebuffSkill; // explicit cast

            float rollValue = (float)new Random(DateTime.Now.Millisecond).NextDouble();

            if (rollValue <= defuffSkill.EffectChance)
            {
                target.ModifyParamFactor(defuffSkill.ParameterType, defuffSkill.EffectValue);
            }
        }
    }

    private void ModifyHP(int delta)
    {
        HP += delta;
    }
}