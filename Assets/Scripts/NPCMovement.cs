using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;
using TMPro;

public class NPCMovement : MonoBehaviour
{
    public List<Transform> waypoints;
    public float waitTime = 5f;  // Time to wait at each waypoint.
    public float Speed;

    private NavMeshAgent agent;
    private int currentWaypointIndex;
    private bool isMoving = true;

    public AnimationClip animationClip;

    public AnimationClip animationClip2;

    private Animator animator;

    public int npcID ; // Assign a unique ID to each NPC in the Unity Editor
    public OrderManager orderManager;

    public Transform counterWaypoint;

    public NPCCaller Caller;

    public float pickupTime = 5f;
    public GameObject OrderBag;

    public GameObject phone;

    public Transform exitWaypoint;

    public GameObject PaymentText;
    public PaymentSystem paymentSystem;
     public int paymentAmount = 50;
    

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
           
            MoveToCounter();
            Caller.readyOrders.Remove(npcID);
        }
       
    }
    }

        void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("OrderTable"))  
        {      
         orderManager.NPCReachedTrigger(npcID);
        }

        if (other.CompareTag("PickUpCounter"))
        {
            Debug.Log("NPC with ID " + npcID + " has reached the counter.");
            // Call the leaving action when the NPC hits the PickupArea trigger
            StartCoroutine(LeavingRoutine());
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
           
           
            DoSpecialAction();
            yield break;  // Stop the coroutine 
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
            phone.SetActive(true);

            //Debug.Log("Special action at the last waypoint!");
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

 IEnumerator LeavingRoutine()
    {
         // Wait for a specified time at the counter
        yield return new WaitForSeconds(pickupTime);

         if (animationClip2 != null)
    {
        // Get the animation state name from the clip
        string stateName = animationClip2.name;

        // Check if the state exists in the Animator Controller
        if (animator.HasState(0, Animator.StringToHash(stateName)))
        {
            animator.Play(stateName);
          
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
        if (agent != null && exitWaypoint != null)
        {
         if (paymentSystem != null && paymentAmount > 0)
            {
                paymentSystem.AddPayment(paymentAmount);
            }

            PaymentText.SetActive(true);
            OrderBag.SetActive(true);
            // Set the destination to the counter waypoint
            agent.SetDestination(exitWaypoint.position);
          
        }

       

        
    }

      public void MoveToExitWaypoint()
    {
        if (agent != null && exitWaypoint != null)
        {
            // Set the destination to the exit waypoint
            agent.SetDestination(exitWaypoint.position);
        }
    }

}
