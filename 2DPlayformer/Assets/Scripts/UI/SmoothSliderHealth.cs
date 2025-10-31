using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderHealth : MonoBehaviour
{
    [SerializeField] private Wellness _health;
    [SerializeField] private Slider _slider;
    [SerializeField] protected float _smoothSpeed =5f;

    private float _targetValue;

    private void OnEnable()
    {
        _health.HealthChanged += UpdateBar;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateBar;
    }

    private void Update()
    {
        _slider.value = Mathf.Lerp(_slider.value, _targetValue, _smoothSpeed * Time.deltaTime);
    }

    private void UpdateBar(int current, int max)
    {
        _slider.maxValue = max;
        _targetValue = current;
    }
}
