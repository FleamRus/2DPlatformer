using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public event Action<Health> DieCharacter;
    public event Action<int, int> Changed;
    public event Action<int, int> Initialized;

    [SerializeField] private int _maxValue = 100;

    private int _currentValue;
    private int _minValue = 0;

    private void Awake()
    {
        _currentValue = _maxValue;

        Changed?.Invoke(_currentValue, _maxValue);
        Initialized?.Invoke(_currentValue, _maxValue);
    }

    public void Heal(int amount)
    {
        if (amount > 0)
        {
            _currentValue += amount;
            _currentValue = Mathf.Clamp(_currentValue, _minValue, _maxValue);
            Changed?.Invoke(_currentValue, _maxValue);
        }
    }

    public void TakeDamage(int amount)
    {
        if (amount > 0)
        {
            _currentValue -= amount;
            _currentValue = Mathf.Clamp(_currentValue, _minValue, _maxValue);
            Changed?.Invoke(_currentValue, _maxValue);
        }

        if (_currentValue <= 0)
            Die();
    }

    private void Die()
    {
        DieCharacter?.Invoke(this);
    }
}
