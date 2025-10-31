using UnityEngine;
using UnityEngine.UI;

public class SliderHealth : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _health.Changed += UpdateBar;
    }

    private void OnDisable()
    {
        _health.Changed -= UpdateBar;
    }

    private void UpdateBar(int current, int max)
    {
        _slider.maxValue = max;
        _slider.value = current;
    }
}
