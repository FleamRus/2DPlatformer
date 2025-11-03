using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private AnimationControl _animation;
    [SerializeField] private GroundChecker _checkGrounded;

    [SerializeField] private CharacterJumper _characterJumper;
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private CharacterRotator _characterRotator;

    private float _moveInput;
    private bool _jumpRequested;

    private void Update()
    {
        _moveInput = _inputReader.MoveDirection;

        _characterRotator.RotateCharacter(_moveInput);

        _animation.MoveAnimation(_moveInput);

        if (_inputReader.JumpPressed && _checkGrounded.IsGrounded)
        {
            _jumpRequested = true;
            _inputReader.ConsumeJump();
        }
    }

    private void FixedUpdate()
    {
        _characterMover.MoverCharacter(_moveInput);

        if (_jumpRequested)
        {
            _characterJumper.Jump();
            _jumpRequested = false;
        }
    }
}
