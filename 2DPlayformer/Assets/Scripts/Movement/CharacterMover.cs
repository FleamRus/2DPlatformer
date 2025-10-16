using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;

    private Rigidbody2D _riginbody;

    private void Awake()
    {
        _riginbody = GetComponent<Rigidbody2D>();
    }

    public void MoverCharacter(float direction)
    {
        Vector2 velocity = _riginbody.velocity;
        velocity.x = direction * _moveSpeed;
        _riginbody.velocity = velocity;
    }
}

