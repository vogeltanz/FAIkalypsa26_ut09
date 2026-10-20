using UnityEngine;

public class GhoulAI : MonoBehaviour
{
    [SerializeField]
    bool playerIsVisible = false;

    public void SetPlayerVisibility(bool isVisible)
    {
        playerIsVisible = isVisible;
    }
}
