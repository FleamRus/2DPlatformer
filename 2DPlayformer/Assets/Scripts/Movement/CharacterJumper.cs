using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1.0f;

    private Rigidbody2D _riginbody;

    private void Awake()
    {
        _riginbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _riginbody.velocity = new Vector2(_riginbody.velocity.x, _jumpForce);
    }
}
