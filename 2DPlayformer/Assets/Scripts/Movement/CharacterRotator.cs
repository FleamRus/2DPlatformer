using UnityEngine;

public class CharacterRotator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void RotateCharacter(float direction)
    {
        if (direction != 0)
        {
            _spriteRenderer.flipX = direction < 0;
        }
    }
}
