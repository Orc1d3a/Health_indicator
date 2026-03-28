using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Slider _usualSlider;
    [SerializeField] private Slider _smoothSlider;

    private Health _health;
    private Coroutine _coroutine;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += UpdateAll;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateAll;
    }

    public void UpdateAll()
    {
        UpdateText();
        UpdateUsualSlider();

        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(UpdateSmoothSlider());
    }

    private void UpdateText()
    {
        _text.text = $"{_health.CurrentHealth}/{_health.MaxHealth}";
    }

    private void UpdateUsualSlider()
    {
        _usualSlider.value = _health.CurrentHealth / _health.MaxHealth;
    }

    private IEnumerator UpdateSmoothSlider()
    {
        float speed = 0.25f;
        float target = _health.CurrentHealth/_health.MaxHealth;

        while (Mathf.Abs(_smoothSlider.value - target) > 0.002f)
        {
            _smoothSlider.value = Mathf.MoveTowards(_smoothSlider.value, target, speed*Time.deltaTime);

            yield return null;
        }
    }
}
