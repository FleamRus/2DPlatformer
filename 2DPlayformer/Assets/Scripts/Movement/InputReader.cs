using UnityEngine;
using Input = UnityEngine.Input;

public class InputReader : MonoBehaviour
{
    private string _horizontalVector = "Horizontal";
    private string _jumpButtom = "Jump";

    public float MoveDirection { get; private set; }
    public bool JumpPressed { get; private set; }

    private void Update()
    {
       MoveDirection= Input.GetAxisRaw(_horizontalVector);

       JumpPressed= Input.GetButtonDown(_jumpButtom);
    }

    public void ConsumeJump()
    { 
    JumpPressed = false;
    }
}
