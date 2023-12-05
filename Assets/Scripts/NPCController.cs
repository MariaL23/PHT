using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class NPCController : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Set the initial destination
        SetDestination();
    }

    void Update()
    {
        // Check if the NPC has reached the current waypoint
        if (navMeshAgent.remainingDistance < 0.1f && !navMeshAgent.pathPending)
        {
            // If the current waypoint is the last one, play the final animation and stop moving
            if (currentWaypointIndex == waypoints.Length - 1)
            {
                animator.SetBool("IsFinalAnimation", true);
                navMeshAgent.isStopped = true;
            }
            else
            {
                // Move to the next waypoint
                currentWaypointIndex++;
                SetDestination();

                // If the current waypoint is the second one, wait for 5 seconds
                if (currentWaypointIndex == 1)
                {
                    StartCoroutine(WaitAtWaypoint(5f));
                }
            }
        }
    }

    void SetDestination()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
        else
        {
            Debug.LogError("Index out of bounds!");
        }
    }

    IEnumerator WaitAtWaypoint(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        // Move to the next waypoint after the wait
        currentWaypointIndex++;
        SetDestination();
    }
}
