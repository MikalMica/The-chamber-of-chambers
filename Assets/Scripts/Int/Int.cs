using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu (menuName = "Int")]
public class Int : ScriptableObject
{
    [SerializeField] int _value;
    public int Value
    {
        get => _value;
        private set
        {
            _value = value;
            _onValueChanged.Invoke(value);
        }
    }

    UnityEvent<int> _onValueChanged = new UnityEvent<int>();

    public void SetValue(int value) => Value = value;
    public void AddValue(int value) => Value += value;

    public void Suscribe(UnityAction<int> action) => _onValueChanged.AddListener(action);
    public void Unsuscribe(UnityAction<int> action) => _onValueChanged.RemoveListener(action);
}
