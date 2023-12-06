using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public int npcID;
    public OrderManager orderManager;
    public OrderBagScript orderBagScript;

    public List<Transform> waypoints;
    public float waitTime = 5f;  // Time to wait at each waypoint.
    public float Speed;
    public Transform counterWaypoint;

    public Transform exitWaypoint;
    private NavMeshAgent agent;
    private int currentWaypointIndex;
    private bool isMoving = true;
    private Animator animator;
    public AnimationClip animationClip;

    public NPCCaller Caller;

    public float pickupTime = 5f;

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

     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OrderTable"))
        {
            orderManager.NPCReachedTrigger(npcID);
           
        }
        else if (other.CompareTag("CounterWaypoint"))
        {
            Debug.Log("Reached the counter waypoint!");
            // Call the leaving action when the NPC hits the PickupArea trigger
            StartCoroutine(LeavingRoutine());
        }
    }

    private void DoSpecialAction()
    {
           if (Caller != null)
        {
            Caller.AddReadyNPC(npcID);
             if (Caller.IsOrderReady(npcID))
        {
            // Trigger NPC to move to a waypoint
            MoveToCounter();
        }
        }
       

        if (animationClip != null)
        {
            // Get the animation state name from the clip
            string stateName = animationClip.name;

            // Check if the state exists in the Animator Controller
            if (animator.HasState(0, Animator.StringToHash(stateName)))
            {
                animator.Play(stateName);
                transform.Rotate(0f, 180f, 0f);
                Debug.Log("Special action at the last waypoint!");

                // Notify ready NPCs when the animation is played

           
              
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

 
    public void MoveToCounter()
    {
        // Ensure the NPC has a NavMeshAgent component
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null && counterWaypoint != null)
        {
            // Set the destination to the counter waypoint
            agent.SetDestination(counterWaypoint.position);
          
        }
    }

      private void PerformLeavingAction()
    {
       StartCoroutine(LeavingRoutine());
       Debug.Log("Leaving action performed!");
    }

    IEnumerator LeavingRoutine()
    {
         // Wait for a specified time at the counter
        yield return new WaitForSeconds(pickupTime);

        
        if (agent != null && exitWaypoint != null)
        {
            animator.SetBool("OrderPickup", true);
            // Set the destination to the counter waypoint
            agent.SetDestination(exitWaypoint.position);
          
        }

       

        
    }

}