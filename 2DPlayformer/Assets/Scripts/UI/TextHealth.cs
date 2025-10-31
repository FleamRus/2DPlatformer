using UnityEngine;
using TMPro;

public class TextHealth : MonoBehaviour
{
    [SerializeField] private Wellness _health;
    [SerializeField] private TMP_Text _textMeshPro;

    private void OnEnable()
    {
        _health.HealthChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateHealth;
    }

    private void UpdateHealth(int current, int max)
    {
        _textMeshPro.text = $"{current}/{max}";
    }
}
