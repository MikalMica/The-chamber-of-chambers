using UnityEngine;
using UnityEngine.Events;

public class IntReceiver : MonoBehaviour
{
    [SerializeField] Int _int;
    [SerializeField] UnityEvent<int> _onValueChanged;

    private void OnEnable() {
        _int.Suscribe(OnValueChanged);
    }

    private void OnDisable() {
        _int.Unsuscribe(OnValueChanged);
    }

    void OnValueChanged(int value){
        _onValueChanged.Invoke(value);
    }
}
