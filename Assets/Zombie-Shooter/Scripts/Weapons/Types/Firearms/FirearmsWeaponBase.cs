using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class FirearmsWeaponBase : WeaponBase
{
    private int _currentCountOfBullets;
    private Transform _cameraTransform;
    private Transform _characterTransform;

    public FirearmsWeaponBase() 
    {
        if (MaxCountOfBullets > 0) _currentCountOfBullets = MaxCountOfBullets;
        else throw new System.ArgumentException($"{nameof(MaxCountOfBullets)} must be greater than 0");
    }

    protected abstract int MaxCountOfBullets { get; }
    protected abstract float TimeRecharge { get; }
    protected abstract AudioSource ShotSource { get; }

    public override void Attack()
    {
        if (IsAttackPosible && _currentCountOfBullets > 0)
        {
            MakeSoundOfShot();
            ReduceCurrentCountOfBullets();

            if (Physics.Raycast(_cameraTransform.position, _characterTransform.forward, out RaycastHit hit, 40))
            {
                if (hit.transform.gameObject.TryGetComponent(out Enemy enemy)) enemy.Health.SendHit(Damage);
            }

        }
    }

    private void ReduceCurrentCountOfBullets() => _currentCountOfBullets--;
    private void MakeSoundOfShot() => ShotSource.Play();
}
