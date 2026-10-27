using UnityEngine;
using UnityEngine.Events;

public class GhoulEyes : MonoBehaviour
{
    [SerializeField]
    float detectionRange = 10f;

    [SerializeField]
    float lookAtPlayerRange = 2f;

    public UnityEvent<bool> IsVisible;

    public UnityEvent<bool> LooksAtPlayer;

    public void CheckVisibility(GameObject gameObject)
    {
        if (gameObject != null && gameObject.CompareTag("Player"))
        {
            // Player is detected
            Debug.Log("Player detected by GhoulEyes.");

            Vector3 playerPosition = gameObject.transform.position + Vector3.up * 1.5f;
            Vector3 directionToPlayer = (playerPosition - transform.position).normalized;
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

            RaycastHit hitInfoLookAtPlayer;
            Physics.Raycast(transform.position + transform.up * -1f, transform.forward, out hitInfoLookAtPlayer, lookAtPlayerRange, ~LayerMask.GetMask("Eyes"));
            Debug.DrawRay(transform.position + transform.up * -1f, transform.forward * lookAtPlayerRange, Color.green, 1f);
            if (hitInfoLookAtPlayer.collider != null && hitInfoLookAtPlayer.collider.gameObject.CompareTag("Player"))
            {
                // Player is visible
                Debug.Log("Ghoul looks at Player.");
                LooksAtPlayer?.Invoke(true);
            }
            else
            {
                // Player is not visible
                Debug.Log("Ghoul doesn't look at Player.");
                LooksAtPlayer?.Invoke(false);
            }
        }
        else
        {
            // Player is not detected
            Debug.Log("Player not detected by GhoulEyes.");
        }
    }
}
