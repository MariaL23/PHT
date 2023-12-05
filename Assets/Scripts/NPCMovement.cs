using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public List<Transform> waypoints;
    public float waitTime = 5f;  // Time to wait at each waypoint.
    public float Speed;

    private NavMeshAgent agent;
    private int currentWaypointIndex;
    private bool isMoving = true;

    public AnimationClip animationClip;

    private Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.speed = Speed;

        if (waypoints.Count > 0)
        {
            MoveToPoint(waypoints[0].position);
        }
    }

    private void Update()
    {
        if (isMoving && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            isMoving = false;  // Stop checking in this cycle
            animator.SetBool("walking", false);
            StartCoroutine(WaitAndMove());
        }
    }

    IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(waitTime);

        // Proceed to the next waypoint.
        currentWaypointIndex++;



        // Check if the NPC has reached the last waypoint.
        if (currentWaypointIndex >= waypoints.Count)
        {    
            Debug.Log("Reached the last waypoint!");
            // Special action for the last waypoint.
            DoSpecialAction();
            yield break;  // Stop the coroutine after the special action
        }
        
        MoveToPoint(waypoints[currentWaypointIndex].position);
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
        isMoving = true;
        animator.SetBool("walking", true);
    }

    private void DoSpecialAction()
    {
        if (animationClip != null)
    {
        // Get the animation state name from the clip
        string stateName = animationClip.name;

        // Check if the state exists in the Animator Controller
        if (animator.HasState(0, Animator.StringToHash(stateName)))
        {
            animator.Play(stateName);
            Debug.Log("Special action at the last waypoint!");
        }
        else
        {
            Debug.LogError($"Animation state '{stateName}' not found in the Animator Controller.");
        }
    }
    else
    {
        Debug.LogError("Animation clip is not assigned.");
    }
    }
}
