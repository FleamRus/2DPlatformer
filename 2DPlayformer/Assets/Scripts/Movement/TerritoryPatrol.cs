using UnityEngine;

public class TerritoryPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    private float _directionMove;
    private float _stopDistance = 1f;
    private int _currentWaypoint;
    private Transform _currentTarget;
    private int _rightDirection = 1;

    private void Start()
    {
        if (_waypoints.Length > 0)
        {
            _currentTarget = _waypoints[_currentWaypoint];
        }
    }

    private void Update()
    {
        if (_currentTarget == null)
            return;
    }

    public float SetTerritoyPatrol()
    {
        Vector3 direction = (_currentTarget.position - transform.position).normalized;
        _directionMove = Mathf.Sign(direction.x);

        return _directionMove;
    }

    public void EvaluteDistance()
    {
        float sqrDistance = (_currentTarget.position - transform.position).sqrMagnitude;

        if (sqrDistance < _stopDistance * _stopDistance)
        {
            SelectNextWaypoint();
        }
    }

    private void SelectNextWaypoint()
    {
        int beginerWaypoinIndex = 0;
        int stepBackIndex = 2;
        int liftingIndex = 1;
        int omittingIndex = 1;

        _currentWaypoint += _rightDirection;

        if (_currentWaypoint >= _waypoints.Length)
        {
            _currentWaypoint = _waypoints.Length - stepBackIndex;
            _rightDirection = omittingIndex;
        }
        else if (_currentWaypoint < beginerWaypoinIndex)
        {
            _currentWaypoint = liftingIndex;
            _rightDirection = liftingIndex;
        }

        _currentTarget = _waypoints[_currentWaypoint];
    }
}
