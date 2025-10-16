using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TurnPoint : MonoBehaviour
{
    public event Action<EnemiesMover> EnemyIsArrived;

    private void Awake()
    {
        Collider2D collider2D = GetComponent<Collider2D>();
        collider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemiesMover enemiy))
        {
            EnemyIsArrived?.Invoke(enemiy);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.2f);
    }
}
