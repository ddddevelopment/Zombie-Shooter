using System;
using UnityEngine;

public class CharacterHealth
{
    public event Action<int> OnHit;
    
    public int _maxHealth = 100;
    private int _currentHealth;


    public CharacterHealth(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;
        OnHit += TakeDamage;
    }

    ~CharacterHealth()
    {
        OnHit -= TakeDamage;
    }
    
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public void SendHit(int damage)
    {
        OnHit?.Invoke(damage);
    }

    private void TakeDamage(int damage)
    {
        if (_currentHealth - damage <= 0)
        {
            Die(); 
            return; 
        }

        _currentHealth -= damage;
    }

    private void TakeRewardForKilling(int rewardForKilling)
    {
        if (_currentHealth + rewardForKilling > _maxHealth)
        {
            _currentHealth = _maxHealth;
            return;
        }

        _currentHealth += rewardForKilling;
    }

    private void Die()
    {
        Debug.Log("Died");
    }
}
