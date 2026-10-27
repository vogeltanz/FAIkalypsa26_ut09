using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GhoulAI : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    Animator animator;

    [SerializeField]
    bool playerIsVisible = false;

    [SerializeField]
    bool lookAtPlayer = false;

    public void SetPlayerVisibility(bool isVisible)
    {
        playerIsVisible = isVisible;
        animator.SetBool("PlayerIsVisible", playerIsVisible);
    }

    public void SetLookAtPlayer(bool lookAtPlayer)
    {
        this.lookAtPlayer = lookAtPlayer;
        animator.SetBool("LooksAtPlayer", this.lookAtPlayer);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.GetBehaviour<GhoulRunBehavior>().Player = player;
    }

    private void Update()
    {
        float playerDistance = Vector3.Distance(player.transform.position, transform.position);
        animator.SetFloat("PlayerDistance", playerDistance);
    }
}
