using UnityEngine;
using UnityEngine.Events;

public class GroundDetector : MonoBehaviour
{
    public UnityEvent<bool> IsGrounded;

    private void OnTriggerEnter(Collider other)
    {
        IsGrounded?.Invoke(true);
    }

    private void OnTriggerStay(Collider other)
    {
        IsGrounded?.Invoke(true);
    }

    private void OnTriggerExit(Collider other)
    {
        IsGrounded?.Invoke(false);
    }
}
