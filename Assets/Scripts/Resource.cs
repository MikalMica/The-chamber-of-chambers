using System;
using UnityEngine;
using UnityEngine.Events;

public class Resource : MonoBehaviour
{
    HealthHandler _healthHandler;
    [SerializeField] Int _resourceContainer;
    
    [SerializeField] UnityEvent _onGetDamage;
    [SerializeField] UnityEvent _onGetResource;

    private void Awake() {
        _healthHandler = GetComponent<HealthHandler>();
        _healthHandler.SuscribeToGetDamage(GetDamage);
        _healthHandler.SuscribeToDie(()=>{Destroy(gameObject);});
    }

    private void OnDestroy() {
        _healthHandler.UnsuscribeToGetDamage(GetDamage);
        _healthHandler.UnsuscribeToDie(()=>{Destroy(gameObject);});
    }

    public void GetDamage(int damage)
    {
        int realValue = Math.Clamp(damage, 0, _healthHandler.Health);
        _resourceContainer.AddValue(realValue);
        _onGetDamage.Invoke();
    }
}
