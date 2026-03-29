using UnityEngine;

public class ButtonsHandler : MonoBehaviour
{
    [SerializeField] private Health _health;

    private int _damageValue = 5;
    private int _healValue = 11;

    public void TakeDamage()
    {
        _health.TakeDamage(_damageValue);
    }

    public void Heal()
    {
        _health.Heal(_healValue);
    }
}
