using UnityEngine;

public class SimpleTransformMovementController : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] float _jumpForce = 5f;

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += movement * _speed * Time.deltaTime;
    }
}
