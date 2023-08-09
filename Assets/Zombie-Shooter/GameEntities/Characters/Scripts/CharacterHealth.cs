using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxHealth = 100;

    private int _currentHealth;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public void Initialize()
    {
        _currentHealth = _maxHealth;
    }

    private void TakeDamage(int damage)
    {
        if (_currentHealth - damage <= 0) Die();
        else _currentHealth -= damage;
    }

    private void TakeRewardForKilling(int rewardForKilling)
    {
        if (_currentHealth + rewardForKilling > _maxHealth) _currentHealth = _maxHealth;
        else _currentHealth += rewardForKilling;
    }

    private void Die()
    {
        Debug.Log("Died");
    }
}
