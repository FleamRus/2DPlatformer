using UnityEngine;

public class CharacterRotator : MonoBehaviour
{
    public void RotateCharacter(float direction)
    {
        if (direction != 0)
        {
            if(direction >0)
                {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}
