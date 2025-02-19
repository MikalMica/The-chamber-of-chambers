using UnityEngine;
using UnityEngine.Events;

public class Resource : MonoBehaviour
{
    [SerializeField] int _health = 100;
    [SerializeField] Int _resourceContainer;
    
    [SerializeField] UnityEvent _onGetDamage;
    [SerializeField] UnityEvent _onGetResource;

    public void GetDamage(int damage)
    {
        _health -= damage;
        _resourceContainer.AddValue(damage);
        _onGetDamage.Invoke();

        if(_health <= 0)
        {
            _onGetResource.Invoke();
            Destroy(gameObject);
        }
    }
}
