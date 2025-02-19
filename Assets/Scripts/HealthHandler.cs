using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] int _health = 100;
    public int Health => _health;

    [SerializeField] UnityEvent<int> _onGetDamage;
    [SerializeField] UnityEvent _onDie;

    public void GetDamage(int damage)
    {
        _health -= damage;
        _onGetDamage.Invoke(damage);

        if(_health <= 0) _onDie.Invoke();
    }

    public void SuscribeToGetDamage(UnityAction<int> action) => _onGetDamage.AddListener(action);
    public void UnsuscribeToGetDamage(UnityAction<int> action) => _onGetDamage.RemoveListener(action);

    public void SuscribeToDie(UnityAction action) => _onDie.AddListener(action);
    public void UnsuscribeToDie(UnityAction action) => _onDie.RemoveListener(action);
}
