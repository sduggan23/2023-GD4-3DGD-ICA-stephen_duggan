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
            Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(camRay, out hit))
            {
                //if (hit.collider != null && hit.collider.CompareTag("Ground"))
                //{
                    MovePlayer(hit.point);
                //}
                Vector3 pointToLook = camRay.GetPoint(hit.distance);
                Debug.DrawLine(camRay.origin, pointToLook, Color.blue);
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }

        }

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            animator.SetBool("IsWalking", false);
        }
        else
        {
            animator.SetBool("IsWalking", true);
        }
    }
    private void MovePlayer(Vector3 destination)
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.SetDestination(destination);
        }
    }
}