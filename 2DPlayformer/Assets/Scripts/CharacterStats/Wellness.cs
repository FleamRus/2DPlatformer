using System;
using UnityEngine;

public class Wellness : MonoBehaviour, IDamageable
{
    public event Action<Wellness> DieCharacter;

    [SerializeField] private int _maxHealth = 100;

    private int _currentHealth;
    private int _minHealth = 0;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(int amount)
    {
        if (amount > 0)
        {
            _currentHealth += amount;
            _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
        }
    }

    public void TakeDamage(int amount)
    {
        if (amount > 0)
        {
            _currentHealth -= amount;
            _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
        }

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        DieCharacter?.Invoke(this);
    }
}
