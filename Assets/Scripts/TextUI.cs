using TMPro;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class TextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += UpdateText;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateText;

    }

    private void UpdateText()
    {
        _text.text = $"{_health.CurrentHealth}/{_health.MaxHealth}";
    }
}
