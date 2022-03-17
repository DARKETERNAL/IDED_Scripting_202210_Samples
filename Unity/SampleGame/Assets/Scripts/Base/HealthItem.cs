using System;

public class HealthItem : Item
{
    public override float EffectValue
    {
        get => base.EffectValue;
        protected set => base.EffectValue = Math.Max(1F, (float)Math.Round(value));
    }

    public HealthItem() : base()
    {
    }

    public HealthItem(string name, float effectValue) : base(name, effectValue)
    {
    }
}