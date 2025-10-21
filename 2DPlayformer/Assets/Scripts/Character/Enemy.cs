using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private AnimationControl _animation;

    [Header("Ёлементы движени€")]
    [SerializeField] private CharacterRotator _characterRotator;
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private TerritoryPatrol _territoryPatrol;

    private float _stopDistance = 1f;
    private int _currentWaypoinIndex;
    private Transform _currentTarget;
    private int _RightDirection = 1;
    private float _directionMove;

    private void Start()
    {
        if (_waypoints.Length > 0)
        {
            _currentTarget = _waypoints[_currentWaypoinIndex];
        }
    }

    private void Update()
    {
        if (_currentTarget == null)
            return;

        CheckDistance();

        _directionMove = _territoryPatrol.SetTerritoyPatrol(_currentTarget);
    }

    private void FixedUpdate()
    {
        MoveTorwardTarget(_directionMove);
    }

    private void MoveTorwardTarget(float direction)
    {
        _characterMover.MoverCharacter(direction);

        _characterRotator.RotateCharacter(direction);

        _animation.MoveAnimation(direction);
    }

    private void CheckDistance()
    {
        float sqrDistance = (_currentTarget.position - transform.position).sqrMagnitude;

        if (sqrDistance < _stopDistance * _stopDistance)
        {
            GoToNextWaypoint();
        }
    }

    private void GoToNextWaypoint()
    {
        int beginerWaypoinIndex = 0;
        int stepBackIndex = 2;
        int liftingIndex = 1;
        int omittingIndex = 1;

        _currentWaypoinIndex += _RightDirection;

        if (_currentWaypoinIndex >= _waypoints.Length)
        {
            _currentWaypoinIndex = _waypoints.Length - stepBackIndex;
            _RightDirection = omittingIndex;
        }
        else if (_currentWaypoinIndex < beginerWaypoinIndex)
        {
            _currentWaypoinIndex = liftingIndex;
            _RightDirection = liftingIndex;
        }

        _currentTarget = _waypoints[_currentWaypoinIndex];
    }
}
