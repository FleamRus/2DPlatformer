using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoverEnemies : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ÑontrolAnimation _animation;

    private bool _movingRight = false;
    private Rigidbody2D _riginbody;
    private TurnPoint[] _turnPoints;

    private void Awake()
    {
        _riginbody = GetComponent<Rigidbody2D>();
        _turnPoints = FindObjectsOfType<TurnPoint>();
    }

    private void OnEnable()
    {
        foreach (var turnPoint in _turnPoints)
        {
            turnPoint.EnemyIsArrived += EnemyArrived;
        }
    }

    private void OnDisable()
    {
        foreach (var turnPoint in _turnPoints)
        {
            turnPoint.EnemyIsArrived -= EnemyArrived;
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float direction = _movingRight ? 1 : -1;

        _riginbody.velocity = new Vector2(direction * _moveSpeed, _riginbody.velocity.y);

        if (direction != 0)
        {
            _spriteRenderer.flipX = direction < 0;
        }

        _animation.AnimationMove(direction);
    }

    private void FlipDirection()
    {
        _movingRight = !_movingRight;
    }

    private void EnemyArrived(MoverEnemies enemy)
    {
        if (enemy == this)
        {
            FlipDirection();
        }
    }
}
