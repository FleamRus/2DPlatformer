using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private AnimationControl _animation;

    [Header("Ёлементы движени€")]
    [SerializeField] private CharacterRotator _characterRotator;
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private TerritoryPatrol _territoryPatrol;

    private float _directionMove;

    private void Update()
    {
        _territoryPatrol.CheckDistance();

        _directionMove = _territoryPatrol.SetTerritoyPatrol();
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
