using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderCooldown : MonoBehaviour
{
    [SerializeField] private VampirismSpell _vampirism;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _smoothSpeed = 20f;

    private float _targetValue;
    private Coroutine _smoothCorutine;

    private void OnEnable()
    {
        _vampirism.ChangeValue += UpdateBar;
    }

    private void OnDisable()
    {
        _vampirism.ChangeValue -= UpdateBar;
    }

    private void UpdateBar(float current, float max)
    {
        _slider.maxValue = max;
        _targetValue = current;

        if (_smoothCorutine != null)
            StopCoroutine(_smoothCorutine);

        _smoothCorutine = StartCoroutine(SmoothingValue());
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
