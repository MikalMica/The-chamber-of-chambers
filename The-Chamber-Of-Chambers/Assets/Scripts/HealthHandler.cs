using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] int _health = 100;

    [SerializeField] UnityEvent<int> _onGetDamage;
    [SerializeField] UnityEvent _onDie;

    public void GetDamage(int damage)
    {
        _health -= damage;
        _onGetDamage.Invoke(damage);

        if(_health <= 0) _onDie.Invoke();
    }
}
