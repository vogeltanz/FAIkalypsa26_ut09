using UnityEngine;
using UnityEngine.Events;

public class PlayerDetector : MonoBehaviour
{
    public UnityEvent<GameObject> IsDetected;

    private void OnTriggerEnter(Collider other)
    {
        IsDetected?.Invoke(other.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        IsDetected?.Invoke(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        IsDetected?.Invoke(null);
    }
}
