using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]

public class UsualBarUI : MonoBehaviour
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
        _slider.value = _health.CurrentHealth / _health.MaxHealth;
    }
}
