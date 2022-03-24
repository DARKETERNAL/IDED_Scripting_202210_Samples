public interface IWeapon
{
    float Atk { get; }

    void PerformSpecialAttack(Character target);
}