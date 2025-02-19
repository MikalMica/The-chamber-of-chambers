using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ChamberBrain : MonoBehaviour
{
    Animator _animator;
    Resource _target;
    [SerializeField] float _speed = 5f;
    [SerializeField] int _damage = 10;
    [SerializeField] float _attackFrequency = 1f;
    [SerializeField] float _attackRange = 0.1f;

    Rigidbody _rigidbody;
    UnityAction _currentAction;

    private void Awake() {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();

        _currentAction = Follow;
    }

    private void Update() {
        if(_target != null) Run();
        else _animator.SetBool("isMoving", false);
    }

    void Run() {
        _currentAction.Invoke();
    }

    void Follow()
    {
        _animator.SetBool("isMoving", true);

        Vector3 direction = (_target.transform.position - transform.position).normalized;
        _rigidbody.linearVelocity = new Vector3(direction.x * _speed, _rigidbody.linearVelocity.y, direction.z * _speed);

        if(direction.x < 0) transform.localScale = new Vector3(1, 1, 1);
        else if(direction.x > 0) transform.localScale = new Vector3(-1, 1, 1);

        if(Vector3.Distance(transform.position, _target.transform.position) <= _attackRange) {
            _rigidbody.linearVelocity = Vector3.zero;
            StartCoroutine(AttackTarget());
            _currentAction = ()=>{};
        }
    }

    IEnumerator AttackTarget() {

        while(_target != null) {
            _animator.Play("Attack");
            _target.GetDamage(_damage);
            yield return new WaitForSeconds(_attackFrequency);
        }

        _currentAction = Follow;
    }

    public void SetTarget(Resource target) => _target = target;
}
