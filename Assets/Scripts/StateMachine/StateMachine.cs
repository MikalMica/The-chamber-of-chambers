using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State currentState;

    private void Start() => currentState.Enter();
    private void Update() => currentState.UpdateState();

    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
