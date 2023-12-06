using UnityEngine;

public class OrderBagScript : MonoBehaviour
{
    private int cupNpcID;

    public NPCCaller caller;
    
    public void SetCupNpcID(int finisedOrderID)
    {
        cupNpcID = finisedOrderID;
             if (caller != null)
    {
        
        caller.AddReadyOrder(finisedOrderID);

    }
       // Debug.Log("CupNpcID in OrderBagScript set to: " + cupNpcID);
    }
    
  
  
}