using UnityEngine;
using UnityEngine.Events;

public class ChamberMovement : MonoBehaviour
{
    Animator _animator;
    Transform _target;
    [SerializeField] float _speed = 5f;

    [SerializeField] UnityEvent _onTargetReached;
    Rigidbody _rigidbody;

    private void Awake() {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void FollowTarget() {
        _animator.SetBool("isMoving", true);
        Vector3 direction = (_target.position - transform.position).normalized;
        _rigidbody.linearVelocity = new Vector3(direction.x * _speed, _rigidbody.linearVelocity.y, direction.z * _speed);

        if(direction.x < 0) transform.localScale = new Vector3(1, 1, 1);
        else if(direction.x > 0) transform.localScale = new Vector3(-1, 1, 1);

        if(Vector3.Distance(transform.position, _target.position) < 0.1f) {
            _onTargetReached.Invoke();
        }
    }
}
