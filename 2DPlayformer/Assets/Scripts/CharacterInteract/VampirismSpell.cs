using System;
using System.Collections;
using UnityEngine;

public class VampirismSpell : MonoBehaviour
{
    private readonly Collider2D[] _enemyBuffer = new Collider2D[MaxTargets];

    private const float MaxValueSlider = 1f;
    private const float MinValueSlider = 0f;
    private const int MaxTargets = 10;

    [SerializeField] private Health _health;
    [SerializeField] private int _amount;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _spaceSpellRadius;

    private float _tickRate = 0.5f;
    private float _coolDown = 4f;
    private float _durationSpell = 6f;

    public event Action<float, float> ChangeValue;
    public event Action IsActiv;
    public event Action IsStop;

    private bool _isReady = true;

    public bool IsReady => _isReady;
    public float SpaceSpellRadius => _spaceSpellRadius;

    public void ActivateSpell()
    {
        if (_isReady)
        {
            IsActiv?.Invoke();
            ChangeValue(MaxValueSlider, MaxValueSlider);
            StartCoroutine(WorkSpell());
        }
    }

    private IEnumerator WorkSpell()
    {
        _isReady = false;

        float elapsed = 0f;
        float damageTimer = 0f;

        while (elapsed < _durationSpell)
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= _tickRate)
            {
                damageTimer = 0f;

                int hits= Physics2D.OverlapCircleNonAlloc(transform.position, _spaceSpellRadius,_enemyBuffer, _enemyLayer);

                if (hits > 0)
                {
                    Collider2D closest = FindClosestTarget(hits);

                    if (closest != null && closest.TryGetComponent<IDamageable>(out var target))
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

        ChangeValue?.Invoke(MinValueSlider, MaxValueSlider);
        IsStop?.Invoke();
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

    private Collider2D FindClosestTarget(int hitsCount)
    {
        Collider2D closest = null;
        float closestDistance = float.MaxValue;

        for (int i = 0; i < hitsCount; i++)
        {
            Collider2D col = _enemyBuffer[i];
            if (col == null) continue;

            float dist = Vector2.Distance(transform.position, col.transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closest = col;
            }
        }

        return closest;
    }
}
