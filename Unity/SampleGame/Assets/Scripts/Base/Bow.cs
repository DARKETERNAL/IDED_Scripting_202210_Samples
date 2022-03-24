public class Bow : IWeapon
{
    private const int MAX_AMMO = 10;

    private int ammo = MAX_AMMO;

    public float Atk => ammo > 0 ? Arrow.Atk : 0F;

    public void PerformSpecialAttack(Character target)
    {
        while (ammo > 0)
        {
            target.ApplyDamage((int)Atk);
            ammo--;
        }
    }

    public void Reload()
    {
        ammo = MAX_AMMO;
    }
}