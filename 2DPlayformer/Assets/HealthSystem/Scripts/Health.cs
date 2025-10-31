using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public event Action<Health> DieCharacter;
    public event Action<int, int> HealthChanged;
    public event Action<int, int> Initialized;

    [SerializeField] private int _maxHealth = 100;

    private int _currentHealth;
    private int _minHealth = 0;

    private void Awake()
    {
        _currentHealth = _maxHealth;

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
        Initialized?.Invoke(_currentHealth, _maxHealth);
    }

    public void Heal(int amount)
    {
        if (amount > 0)
        {
            _currentHealth += amount;
            _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }

    public void TakeDamage(int amount)
    {
        if (amount > 0)
        {
            _currentHealth -= amount;
            _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        DieCharacter?.Invoke(this);
    }
}
