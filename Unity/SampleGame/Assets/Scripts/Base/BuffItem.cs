using System;

public class BuffItem : Item
{
    private float effectValue;

    public override float EffectValue
    {
        get => effectValue;
        protected set => effectValue = Math.Min(1F, Math.Abs(value));
    }

    public EParameterType TargetParameter { get; private set; }

    public BuffItem() : base()
    {
        TargetParameter = EParameterType.ATK;
    }

    public BuffItem(string name, float effectValue, EParameterType targetParameter) : base(name, effectValue)
    {
        TargetParameter = targetParameter;
    }
}