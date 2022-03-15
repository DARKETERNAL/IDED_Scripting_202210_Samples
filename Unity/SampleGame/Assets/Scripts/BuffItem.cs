public class BuffItem : Item
{
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