using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2.5f;
    private CharacterController characterController;

    private Vector3 _moveDirection = Vector3.zero;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _moveDirection.x = Input.GetAxis("Horizontal");
        _moveDirection.z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        characterController.Move(_moveDirection.normalized * _moveSpeed * Time.deltaTime);
    }
}
