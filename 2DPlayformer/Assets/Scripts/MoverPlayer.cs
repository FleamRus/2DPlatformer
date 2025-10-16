using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoverPlayer : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _jumpForce = 1.0f;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ÑontrolAnimation _animation;
    [SerializeField] private CheckGrounded _checkGrounded;

    private Rigidbody2D _riginbody;

    private void Awake()
    {
        _riginbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveInput = _inputReader.GetMoveDirection();
        Move(moveInput);

        if (_inputReader.IsJumpPressed() && _checkGrounded.IsGrounded)
        {
            Jump();
        }

        _animation.AnimationMove(moveInput);
    }

    private void Jump()
    {
        _riginbody.velocity = new Vector2(_riginbody.velocity.x, _jumpForce);
    }

    private void Move(float direction)
    {
        Vector2 velocity = _riginbody.velocity;
        velocity.x = direction * _moveSpeed;
        _riginbody.velocity = velocity;

        if (direction != 0)
        {
            _spriteRenderer.flipX = direction < 0;
        }
    }
}
