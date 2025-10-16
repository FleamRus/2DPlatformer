using UnityEngine;
using Input = UnityEngine.Input;

public class InputReader : MonoBehaviour
{
    private string _horizontalVector = "Horizontal";
    private string _jumpButtom = "Jump";

    public float GetMoveDirection()
    {
        return Input.GetAxisRaw(_horizontalVector);
    }

    public bool IsJumpPressed()
    {
        return Input.GetButtonDown(_jumpButtom);
    }
}
