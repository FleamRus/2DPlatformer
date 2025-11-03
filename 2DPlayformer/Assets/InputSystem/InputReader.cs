using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Input/InputReader")]
public class InputReader : ScriptableObject, PlayerInputActions.IPlayerActions
{
    public float MoveDirection { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool VampirismPressed { get; private set; }

    private PlayerInputActions _inputActions;

    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new PlayerInputActions();
            _inputActions.Player.SetCallbacks(this);
        }

        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveDirection = context.ReadValue<Vector2>().x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            JumpPressed = true;
    }

    public void OnVampirism(InputAction.CallbackContext context)
    {
        if (context.performed)
            VampirismPressed = true;
    }

    public void ConsumeJump()
    {
        JumpPressed = false;
    }

    public void ConsumeVampirism()
    {
        VampirismPressed = false;
    }
}
