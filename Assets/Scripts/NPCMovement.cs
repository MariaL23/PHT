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

    public int npcID;  // Assign a unique ID to each NPC in the Unity Editor
    public OrderManager orderManager;

    public Transform counterWaypoint;

    public NPCCaller Caller;

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

       if (Caller != null)
    {
        if (Caller.readyOrders.Contains(npcID))
        {
            // Debug log to check if the condition is being triggered
            Debug.Log("Order ID " + npcID + " is ready!");

            // The order is ready, move to the counter waypoint
            MoveToCounter();
            // Optionally, you can perform other actions when moving to the counter
            Debug.Log("Moving NPC with Order ID " + npcID + " to the counter.");
            
            // Remove the order from the ready list (assuming you don't want it to move to the counter repeatedly)
            Caller.readyOrders.Remove(npcID);
        }
        else
        {
            // Debug log to check if the condition is not being triggered
            Debug.Log("Order ID " + npcID + " is not ready.");
        }
    }
    }

        void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("OrderTable"))  
        {      
         orderManager.NPCReachedTrigger(npcID);
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
         if (Caller != null)
    {
        // Add the NPC ID to the list of ready NPCs
        Caller.AddReadyNPC(npcID);

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



}
