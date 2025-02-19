using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Events;

public class InstanceHandler : MonoBehaviour
{
    UnityEvent _onDestroy = new UnityEvent();

    private void OnDestroy()
    {
        _onDestroy.Invoke();
        _onDestroy.RemoveAllListeners();
    }

    public void AddDestroyListener(UnityAction action)
    {
        Contract.Requires(action != null);
        _onDestroy.AddListener(action);
    }
}
