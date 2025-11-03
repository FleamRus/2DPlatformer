using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Damager : MonoBehaviour
{
    [SerializeField] private int _minDamage = 1;
    [SerializeField] private int _maxDamage = 10;
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<IDamageable>(out var target))
        {
            target.TakeDamage(GetDamage());
        }
    }

    public int GetDamage()
    {
        int damage;

        damage = Random.Range(_minDamage, _maxDamage);

        return damage;
    }
}
