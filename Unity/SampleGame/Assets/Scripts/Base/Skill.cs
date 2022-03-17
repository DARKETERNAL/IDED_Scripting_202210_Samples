using System;

public abstract class Skill
{
    //private string name;

    //public string Name
    //{
    //    get => name;
    //    protected set => name = value;
    //}

    public string Name { get; protected set; }

    public virtual float EffectValue { get; protected set; }

    public Skill()
    {
        Name = "Unused";
        EffectValue = 0F;
    }

    public Skill(string name, float effectValue)
    {
        Name = name;
        EffectValue = effectValue;
    }
}

public class AttackSkill : Skill
{
    public AttackSkill() : base()
    {
    }

    public AttackSkill(string name, float effectValue) : base(name, effectValue)
    {
    }
}

public abstract class SupportSkill : Skill
{
    public SupportSkill() : base()
    {
    }

    public SupportSkill(string name, float effectValue) : base(name, effectValue)
    {
    }
}

public class DebuffSkill : SupportSkill
{
    public EParameterType ParameterType { get; protected set; }

    public float EffectChance { get; protected set; }

    public override float EffectValue
    {
        get => base.EffectValue;
        protected set => base.EffectValue = Math.Min(Math.Abs(value), 0.75F);
    }

    public DebuffSkill() : base()
    {
        ParameterType = EParameterType.ATK;
        EffectChance = 1F;
    }

    public DebuffSkill(string name, float effectValue, EParameterType parameterType, float effectChance) : base(name, effectValue)
    {
        ParameterType = parameterType;
        EffectChance = Math.Abs(effectChance);
    }
}

public class HealSkill : SupportSkill
{
    public override float EffectValue
    {
        get => base.EffectValue;
        protected set => base.EffectValue = Math.Max(1F, (float)Math.Round(value));
    }

    public HealSkill()
    {
        Name = "Cure";
        EffectValue = 10F;
    }

    public HealSkill(string name, float effectValue) : base(name, effectValue)
    {
    }
}