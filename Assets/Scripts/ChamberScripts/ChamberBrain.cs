using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ChamberBrain : MonoBehaviour, ISelectable
{
    Animator _animator;
    HealthHandler _target;
    [SerializeField] float _speed = 5f;
    [SerializeField] int _damage = 10;
    [SerializeField] float _attackFrequency = 1f;
    [SerializeField] float _attackRange = 0.1f;

    [SerializeField] UnityEvent _onSelect;
    [SerializeField] UnityEvent _onDeselect;

    public void Select() => _onSelect.Invoke();
    public void Deselect() => _onDeselect.Invoke();

    Rigidbody _rigidbody;

    private void Awake() {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    IEnumerator Follow()
    {
        _animator.SetBool("isMoving", true);

        while(Vector3.Distance(transform.position, _target.transform.position) > _attackRange)
        {
            Vector3 direction = (_target.transform.position - transform.position).normalized;
            Goto(direction);
            yield return new WaitForEndOfFrame();
        }

        _rigidbody.linearVelocity = Vector3.zero;
        _animator.SetBool("isMoving", false);

        StartCoroutine(AttackTarget());
    }
    
    public void SetTarget(HealthHandler target)
    {
        _target = target;
        StopAllCoroutines();
        StartCoroutine(Follow());
    }

    IEnumerator AttackTarget() {

        while(_target != null && _target.isActiveAndEnabled) {
            _animator.Play("Attack");
            _target.GetDamage(_damage);
            yield return new WaitForSeconds(_attackFrequency);
        }
    }

    public void GotoPosition(Vector3 targetPos)
    {
        StopAllCoroutines();
        StartCoroutine(GotoPositionRoutine(targetPos));
    }

    IEnumerator GotoPositionRoutine(Vector3 targetPos)
    {
        _animator.SetBool("isMoving", true);

        while(Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            Vector3 direction = (targetPos - transform.position).normalized;
            Goto(direction);

            yield return new WaitForEndOfFrame();
        }

        _rigidbody.linearVelocity = Vector3.zero;
        _animator.SetBool("isMoving", false);
    }

    void Goto(Vector3 direction)
    {
        _rigidbody.linearVelocity = new Vector3(direction.x * _speed, _rigidbody.linearVelocity.y, direction.z * _speed);

        if(direction.x < 0) transform.localScale = new Vector3(1, 1, 1);
        else if(direction.x > 0) transform.localScale = new Vector3(-1, 1, 1);
    }
}
