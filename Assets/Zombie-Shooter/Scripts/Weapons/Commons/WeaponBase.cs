using System.Collections;
using UnityEngine;

public abstract class WeaponBase : IWeapon
{
    protected bool IsAttackPosible;

    public WeaponBase() 
    {
        IsAttackPosible = true;
    }

    protected abstract int Damage { get; }
    protected abstract float TimeDelayAttack { get; }

    public abstract void Attack();
}
