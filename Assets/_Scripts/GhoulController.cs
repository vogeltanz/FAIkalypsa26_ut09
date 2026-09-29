using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class GhoulController : MonoBehaviour
{
    Animator _animator;
    InputAction _moveAction;

    [SerializeField]
    [Range(0, 10)]
    float _speed = 3f;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _moveAction = InputSystem.actions.FindAction("Move");
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
    }
}
