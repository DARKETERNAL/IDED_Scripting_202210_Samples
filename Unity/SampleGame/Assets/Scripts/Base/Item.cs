public abstract class Item
{
    public string Name { get; protected set; }
    public virtual float EffectValue { get; protected set; }

    public Item()
    {
        Name = "Unused";
        EffectValue = 0F;
    }

    public Item(string name, float effectValue)
    {
        Name = name;
        EffectValue = effectValue;
    }
}