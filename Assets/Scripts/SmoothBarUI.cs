using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]

public class SmoothBarUI : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += UpdateSlider;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateSlider;
    }

    private void UpdateSlider()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateVisualHealth());
    }

    private IEnumerator UpdateVisualHealth()
    {
        float speed = 0.25f;
        float target = _health.CurrentHealth / _health.MaxHealth;

        while (Mathf.Abs(_slider.value - target) > 0.002f)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, speed * Time.deltaTime);

            yield return null;
        }
    }
}
