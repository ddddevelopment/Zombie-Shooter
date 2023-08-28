using UnityEngine;

public class CharacterAttack : IAttacker
{
    private IWeapon _weapon;

    public CharacterAttack(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public void Attack()
    {
        _weapon.Attack();
    }
}
