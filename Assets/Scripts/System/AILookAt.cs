using UnityEngine;

public class AILookAt : MonoBehaviour
{
    [SerializeField] private Transform player = null;

    private Animator animator;
    private int lookAtPlayerID = Animator.StringToHash("LookAtPlayer");
    private void Awake()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;

        animator = GetComponent<Animator>();
    }

    public Transform GetPlayerTransform()
    {
        return player;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            animator.SetBool(lookAtPlayerID, true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            animator.SetBool(lookAtPlayerID, false);
    }
}
