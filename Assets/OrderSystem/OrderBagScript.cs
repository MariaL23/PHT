using UnityEngine;
using System.Collections.Generic;

public class OrderBagScript : MonoBehaviour
{
    public int cupNpcID;
    public NPCCaller Caller;

    public void SetCupNpcID(int finishedOrderID)
    {
        cupNpcID = finishedOrderID;
        Debug.Log("CupNpcID in OrderBagScript set to: " + cupNpcID);
      
        if (Caller != null)
        {
            // Fix the method call to AddReadyOrder
            Caller.AddReadyOrder(finishedOrderID);
        }
    }

    

}
