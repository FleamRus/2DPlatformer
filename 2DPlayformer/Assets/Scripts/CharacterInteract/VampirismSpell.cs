using System;
using System.Collections;
using UnityEngine;

public class VampirismSpell : MonoBehaviour
{
    private const float MaxValueSlider = 1f;
    private const float MinValueSlider = 0f;

    [SerializeField] private Health _health;
    [SerializeField] private int _amount;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _spaceSpellRadius;
    [SerializeField] private GameObject _sphere;

    private float _tickRate = 0.5f;
    private float _coolDown = 4f;
    private float _durationSpell = 6f;

    public event Action<float, float> ChangeValue;

    private bool _isReady = true;

    public bool IsReady => _isReady;

    private void Awake()
    {
        if(_sphere != null)
        _sphere.SetActive(false);
    }

    private void OnValidate()
    {
        UpdateSphereRadius();
    }

    public void ActivateSpell()
    {
        if (_isReady)
        {
            ChangeValue(MaxValueSlider, MaxValueSlider);
            StartCoroutine(WorkSpell());
        }
    }

    private IEnumerator WorkSpell()
    {
        _isReady = false;

        if(_sphere != null)
            _sphere.SetActive(true);

        float elapsed = 0f;
        float damageTimer = 0f;

        while (elapsed < _durationSpell)
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= _tickRate)
            {
                damageTimer = 0f;

                Collider2D[] enemyCollider = Physics2D.OverlapCircleAll(transform.position, _spaceSpellRadius, _enemyLayer);

                foreach (Collider2D collider in enemyCollider)
                {
                    if (collider.TryGetComponent<IDamageable>(out var target))
                    {
                        target.TakeDamage(_amount);
                        _health.Heal(_amount);
                    }
                }
            }

            float currentValueSlider = Mathf.Clamp01(MaxValueSlider - (elapsed / _durationSpell));
            ChangeValue?.Invoke(currentValueSlider, MaxValueSlider);

            elapsed += Time.deltaTime;

            yield return null;
        }

        if (_sphere != null)
            _sphere.SetActive(false);

        ChangeValue?.Invoke(MinValueSlider, MaxValueSlider);
        StartCoroutine(CoolDownSpell());
    }

    private IEnumerator CoolDownSpell()
    {
        float elapsed = 0f;

        while (elapsed < _coolDown)
        {
            float currentValueSlider = Mathf.Clamp01(elapsed / _coolDown);

            ChangeValue?.Invoke(currentValueSlider, MaxValueSlider);

            elapsed += Time.deltaTime;

            yield return null;
        }

        ChangeValue?.Invoke(MaxValueSlider, MaxValueSlider);

        _isReady = true;
    }

    private void UpdateSphereRadius()
    {
        if (_sphere != null)
        {
            float spriteSizeInUnits = 2.5f;
            float diametr = _spaceSpellRadius / spriteSizeInUnits;
            _sphere.transform.localScale = new Vector3(diametr, diametr, 1f);
        }
    }
}
