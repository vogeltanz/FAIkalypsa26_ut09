using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class GhoulController : MonoBehaviour
{
    Animator _animator;
    Rigidbody _rigidbody;

    InputAction _moveAction;
    InputAction _jumpAction;

    [SerializeField]
    [Range(0, 10)]
    float _speed = 3f;

    [SerializeField]
    float jumpVelocity = 5f;

    bool isGrounded = true;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");

        _jumpAction.performed += JumpAction_performed;
    }

    private void OnDestroy()
    {
        _jumpAction.performed -= JumpAction_performed;
    }

    private void JumpAction_performed(InputAction.CallbackContext obj)
    {
        if (isGrounded)
        {
            _rigidbody.linearVelocity = new Vector3(_rigidbody.linearVelocity.x, jumpVelocity, _rigidbody.linearVelocity.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var vectorMovement = _moveAction.ReadValue<Vector2>();

        if (vectorMovement.x != 0 || vectorMovement.y != 0)
        {
            _animator.SetBool("IsMoving", true);

            var vz = vectorMovement.y * Vector3.forward * Time.deltaTime * _speed;
            var vx = vectorMovement.x * Vector3.right * Time.deltaTime * _speed;

            transform.Translate(vx + vz);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }

        //if (isGrounded && _jumpAction.WasPressedThisFrame())
        //{
        //    _rigidbody.linearVelocity = new Vector3(_rigidbody.linearVelocity.x, jumpVelocity, _rigidbody.linearVelocity.z);
        //}
    }

    public void SetIsGrounded(bool grounded)
    {
        isGrounded = grounded;
    }
}
