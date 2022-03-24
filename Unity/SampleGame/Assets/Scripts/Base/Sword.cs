public class Sword : IWeapon
{
    public float Atk { get; private set; }

    public Sword(float atk = 0)
    {
        atk = 0F;
    }

    public void PerformSpecialAttack(Character target)
    {
        target?.ApplyDamage((int)Atk * 3);
        target?.ModifyParamFactor(EParameterType.DEF, 0.1F);
    }
}