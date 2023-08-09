using UnityEngine;

public class CharacterAttack : MonoBehaviour, IAttacker
{
    private IWeapon weapon;

    public void Attack()
    {
        Debug.Log("Attack");
    }
}
