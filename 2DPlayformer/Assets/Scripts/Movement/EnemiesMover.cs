using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemiesMover : MonoBehaviour
{
    [SerializeField] private AnimationControl _animation;

    [Header("Ёлементы движени€")]
    [SerializeField] private CharacterRotator _characterRotator;
    [SerializeField] private CharacterMover _characterMover;

    private bool _movingRight = false;
    private TurnPoint[] _turnPoints;

    private void Awake()
    {
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

        _characterMover.MoverCharacter(direction);

        _characterRotator.RotateCharacter(direction);

        _animation.MoveAnimation(direction);
    }

    private void FlipDirection()
    {
        _movingRight = !_movingRight;
    }

    private void EnemyArrived(EnemiesMover enemy)
    {
        if (enemy == this)
        {
            FlipDirection();
        }
    }
}
