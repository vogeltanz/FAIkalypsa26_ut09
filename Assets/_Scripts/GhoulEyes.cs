using UnityEngine;
using UnityEngine.Events;

public class GhoulEyes : MonoBehaviour
{
    [SerializeField]
    float detectionRange = 10f;

    public UnityEvent<bool> IsVisible;

    public void CheckVisibility(GameObject gameObject)
    {
        if (gameObject != null && gameObject.CompareTag("Player"))
        {
            // Player is detected
            Debug.Log("Player detected by GhoulEyes.");

            Vector3 directionToPlayer = (gameObject.transform.position - transform.position).normalized;
            Ray ray = new Ray(transform.position, directionToPlayer);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo, detectionRange, ~LayerMask.GetMask("Eyes"));
            Debug.DrawRay(transform.position, directionToPlayer * detectionRange, Color.red, 1f);

            if (hitInfo.collider != null && hitInfo.collider.gameObject.CompareTag("Player"))
            {
                // Player is visible
                Debug.Log("Player is visible to GhoulEyes.");
                IsVisible?.Invoke(true);
            }
            else
            {
                // Player is not visible
                Debug.Log("Player is not visible to GhoulEyes.");
                IsVisible?.Invoke(false);
            }
        }
        else
        {
            // Player is not detected
            Debug.Log("Player not detected by GhoulEyes.");
        }
    }
}
