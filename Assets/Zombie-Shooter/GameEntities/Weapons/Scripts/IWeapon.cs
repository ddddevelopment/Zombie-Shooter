using System.Collections;

public interface IWeapon
{
    int Damage { get; }
    float TimeDelayAttack { get; }
    void Attack();
    IEnumerator DelayAttack(float timeDelayAttack);
}
