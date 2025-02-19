using UnityEngine;
using UnityEngine.Events;

public class State : MonoBehaviour
{
    [SerializeField] private UnityEvent onEnter;
    [SerializeField] private UnityEvent onUpdate;
    [SerializeField] private UnityEvent onExit;

    public void Enter() => onEnter.Invoke();
    public void UpdateState() => onUpdate.Invoke();
    public void Exit() => onExit.Invoke();
}
