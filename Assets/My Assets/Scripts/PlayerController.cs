using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent navMeshAgent;

    void Start()
    {
        cam = Camera.main;
        animator.GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the main camera through the mouse position
            Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(camRay, out hit))
            {
                // Move the player to the clicked point on the ground
                MovePlayer(hit.point);
                // Calculate a point to look
                Vector3 pointToLook = camRay.GetPoint(hit.distance);
                // Make the player face the clicked point (only rotate around Y-axis)
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }

        }
        // Check if the player has reached the destination or is still moving
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            animator.SetBool("IsWalking", false);
        }
        else
        {
            animator.SetBool("IsWalking", true);
        }
    }
    // Move the player to a destination
    private void MovePlayer(Vector3 destination)
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.SetDestination(destination);
        }
    }
}