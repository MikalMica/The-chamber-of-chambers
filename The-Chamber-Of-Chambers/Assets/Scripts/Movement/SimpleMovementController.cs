using UnityEngine;
using UnityEngine.Events;

public class SimpleMovementController : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] float _jumpForce = 5f;
    Rigidbody _rb;

    [SerializeField] UnityEvent _onMove;
    [SerializeField] UnityEvent _onStop;

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _rb.linearVelocity = movement * _speed;
            _onMove.Invoke();
        }
        else{
            _rb.linearVelocity = Vector3.zero;
            _onStop.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
