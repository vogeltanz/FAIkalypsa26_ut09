using UnityEngine;
using UnityEngine.Events;

public class GroundDetector : MonoBehaviour
{
    public UnityEvent<bool> IsGrounded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            IsGrounded?.Invoke(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            IsGrounded?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            IsGrounded?.Invoke(false);
        }
    }
}
