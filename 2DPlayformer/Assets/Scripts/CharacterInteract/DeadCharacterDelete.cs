using UnityEngine;

public class DeadCharacterDelete : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.DieCharacter += DeleteCharacter;
    }

    private void OnDisable()
    {
        _health.DieCharacter -= DeleteCharacter;
    }

    public void DeleteCharacter(Health character)
    {
        Destroy(gameObject);
    }

}

