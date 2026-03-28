using UnityEngine;

public class ButtonsHandler : MonoBehaviour
{
    [SerializeField] private Health _health;

    private int damageValue = 5;
    private int healValue = 11;

    public void TakeDamage()
    {
        _health.TakeDamage(damageValue);
    }

    public void Heal()
    {
        _health.Heal(healValue);
    }
}
