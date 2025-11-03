using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private AnimationControl _animation;

    [SerializeField] private CharacterRotator _characterRotator;
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private TerritoryPatrol _territoryPatrol;
    [SerializeField] private PlayerChaser _playerChaser;

    private float _directionMove;

    private void Update()
    {
        if (!_playerChaser.IsPlayerClose)
        {
            _territoryPatrol.EvaluteDistance();

            _directionMove = _territoryPatrol.SetTerritoyPatrol();

        }
        else
        {
            _directionMove = _playerChaser.SetDirectionToPlayer(transform.position);
        }
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
}
