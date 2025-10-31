using UnityEngine;

public class DeleteDeadCharacter : MonoBehaviour
{
    [SerializeField] private Wellness _wellness;

    private void OnEnable()
    {
        _wellness.DieCharacter += DeleteCharacter;
    }

    private void OnDisable()
    {
        _wellness.DieCharacter -= DeleteCharacter;
    }

    public void DeleteCharacter(Wellness character)
    {
        Destroy(gameObject);
    }

}

