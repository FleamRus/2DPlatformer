using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private ObjectFeel _objectFeel;
    [SerializeField] private int _healAmount = 10;
    [SerializeField] private Wellness _health;

    private void OnEnable()
    {
        _objectFeel.ObjectTouched += Heal;
    }

    private void OnDisable()
    {
        _objectFeel.ObjectTouched -= Heal;
    }

    private void Heal(Collider2D collider)
    {
        if (collider.TryGetComponent(out MedicalKit _))
        {
            _health.Heal(_healAmount);
        }
    }
}
