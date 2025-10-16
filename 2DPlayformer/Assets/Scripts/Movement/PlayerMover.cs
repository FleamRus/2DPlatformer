using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private AnimationControl _animation;
    [SerializeField] private GroundChecker _checkGrounded;

    [Header("Ёлементы движени€")]
    [SerializeField] private CharacterJumper _characterJumper;
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private CharacterRotator _characterRotator;


    private void Awake()
    {
        _characterJumper = GetComponent<CharacterJumper>();
        _characterMover= GetComponent<CharacterMover>();
        _characterRotator= GetComponent<CharacterRotator>();
    }

    private void Update()
    {
        float moveInput = _inputReader.MoveDirection;

        _characterMover.MoverCharacter(moveInput);

        _characterRotator.RotateCharacter(moveInput);

        if (_inputReader.JumpPressed && _checkGrounded.IsGrounded)
        {
            _characterJumper.Jump();
            _inputReader.ConsumeJump();
        }

        _animation.MoveAnimation(moveInput);
    }
}
