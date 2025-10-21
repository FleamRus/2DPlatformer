using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ObjectFeel : MonoBehaviour
{
    [SerializeField] private LayerMask _interactiveLayer;

    public event Action<Collider2D> ObjectTouched;

    private void Awake()
    {
        Collider2D collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _interactiveLayer) == 0)
            return;

        ObjectTouched?.Invoke(collision);
    }
}
