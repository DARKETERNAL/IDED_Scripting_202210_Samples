using System;

public class HealthItem : Item
{
    private float effectValue;

    public override float EffectValue
    {
        get => effectValue;
        protected set => effectValue = Math.Max(1F, (float)Math.Round(value));
    }

    public HealthItem() : base()
    {
    }

    public HealthItem(string name, float effectValue) : base(name, effectValue)
    {
    }
}