using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2.5f;
    [SerializeField] private float _spintSpeed = 5f;

    private CharacterController characterController;

    private Vector3 _moveDirection = Vector3.zero;
    private float _speedBoost = 1;
    private float _sprintSpeedBoost = 1;
    public float SpeedBoost
    {
        get { return _speedBoost; }
        set { _speedBoost = (value >= 1) ? value : SpeedBoost; }
    }

    public float SprintSpeedBoost
    {
        get { return _sprintSpeedBoost; }
        set { _sprintSpeedBoost = (value >= 1) ? value : SprintSpeedBoost; }
    }


    [HideInInspector] public bool canJump = false;
    [HideInInspector] public bool canSprint = false;

    private void Awake()
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
        Move(_moveSpeed * SpeedBoost);
    }

    private void Move(float moveSpeed)
    {
        characterController.Move(_moveDirection.normalized * moveSpeed * Time.deltaTime);
    }

    public void ResetBoosts()
    {
        _speedBoost = 1;
        _sprintSpeedBoost = 1;
        canJump = false;
        canSprint = false;
    }
}
