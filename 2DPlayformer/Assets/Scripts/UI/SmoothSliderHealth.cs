using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderHealth : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] protected float _smoothSpeed = 20f;

    private float _targetValue;
    private Coroutine _smoothCorutine;

    private void OnEnable()
    {
        _health.Initialized += InitBar;
        _health.Changed += UpdateBar;
    }

    private void OnDisable()
    {
        _health.Initialized -= InitBar;
        _health.Changed -= UpdateBar;
    }

    private void UpdateBar(int current, int max)
    {
        _slider.maxValue = max;
        _targetValue = current;

        if (_smoothCorutine != null)
            StopCoroutine(_smoothCorutine);

        _smoothCorutine = StartCoroutine(SmoothingValue());
    }

    private void InitBar(int current, int max)
    {
        _slider.maxValue = max;
        _slider.value = current;
        _targetValue = current;
    }

    private IEnumerator SmoothingValue()
    {
        while (Mathf.Abs(_slider.value - _targetValue) > 0.1f)
        {

            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _smoothSpeed * Time.deltaTime);

            yield return null;
        }

        _slider.value = _targetValue;
    }
}
