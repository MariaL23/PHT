using UnityEngine;

public class OrderBagScript : MonoBehaviour
{
    private int cupNpcID;
    
    public void SetCupNpcID(int newCupNpcID)
    {
        cupNpcID = newCupNpcID;
       
        Debug.Log("CupNpcID in OrderBagScript set to: " + cupNpcID);
    }
    
     public void NPCPickUpBag(NPCControl npc)
    {
        npc.BagPickUp(cupNpcID);
    }
  
}