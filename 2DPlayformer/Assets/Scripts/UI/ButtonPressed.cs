using UnityEngine;
using UnityEngine.UI;

public class ButtonPressed : MonoBehaviour
{
    [SerializeField] private Wellness _health;
    [SerializeField] private Button _buttonDamage;
    [SerializeField] private Button _buttonHeal;

    [Header("Параметры лечения")]
    [SerializeField] private int _damageAmount;
    [SerializeField] private int _healAmount;

    private void Awake()
    {
        _buttonDamage.onClick.AddListener(PressedDamage);
        _buttonHeal.onClick.AddListener(PressedHeal);
    }

    private void OnDestroy()
    {
        _buttonDamage.onClick.RemoveListener(PressedDamage);
        _buttonHeal.onClick.RemoveListener(PressedHeal);
    }

    private void PressedDamage()
    {
        _health.TakeDamage(_damageAmount);
    }

    private void PressedHeal()
    {
        _health.Heal(_healAmount);
    }
}
