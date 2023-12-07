
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderManager : MonoBehaviour
{
    [System.Serializable]
    public class Order
    {
        public string cupSize;
        public string syrup;
        public string boba;
        public string tea;
        public int npcID;  
    }
    
    [System.Serializable]
    public class CompletedOrder
    {
        public Order order;
        public int npcID;
    }




    public List<string> cupSizes = new List<string>();
    public List<string> bobas = new List<string>();
    public List<string> sirups = new List<string>();
    public List<string> teas = new List<string>();

     public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    public TextMeshPro orderText;

    public TextMeshPro CupText;

    public Color correctColor = Color.green;
    public Color wrongColor = Color.red;
    
    public TextMeshPro NextorderText;
    public List<CompletedOrder> completedOrders = new List<CompletedOrder>();
    public List<Order> orders = new List<Order>();

        string GetRandomItem(List<string> itemList)
    {
        int randomIndex = Random.Range(0, itemList.Count);
        return itemList[randomIndex];
    }

    public void Start()
    {
  
    }
public Order NPCReachedTrigger(int npcID)
{
    Order newOrder = new Order();
    newOrder.cupSize = GetRandomItem(cupSizes);
    newOrder.boba = GetRandomItem(bobas);
    newOrder.syrup = GetRandomItem(sirups);
    newOrder.tea = GetRandomItem(teas);
    newOrder.npcID = npcID;  // Assign the NPC ID to the order

    orders.Add(newOrder);

    if (orders.Count >= 1)
    {
        // Display the first order in orderText
        Order currentOrder = orders[0];
        orderText.text =
            "Cupsize: " + currentOrder.cupSize + "\n" +
            "Boba: " + currentOrder.boba + "\n" +
            "Syrup: " + currentOrder.syrup + "\n" +
            "Tea: " + currentOrder.tea;
        
    } 

    if (orders.Count >= 2)
    {
        // Display the second order in NextorderText
        Order nextOrder = orders[1];
        NextorderText.text =
            "Cupsize: " + nextOrder.cupSize + "\n" +
            "Boba: " + nextOrder.boba + "\n" +
            "Syrup: " + nextOrder.syrup + "\n" +
            "Tea: " + nextOrder.tea;
    }

   Debug.Log("Order placed by NPC ID: " + npcID +
              "\nCurrent order: " + newOrder.cupSize + ", " + newOrder.boba + ", " + newOrder.syrup + ", " + newOrder.tea);
   return newOrder;  
}

    private bool cupPlaced = false;
    private bool bobaPlaced = false;
    private bool syrupPlaced = false;
    private bool teaPlaced = false;


    public void CupPlacedTrigger(string playerCupSize, CupPlacement cupPlacement)
    {
    Debug.Log("CupPlacedTrigger called. PlayerCupSize: " + playerCupSize);

    if (orders.Count > 0)
    {
        Order currentOrder = orders[0];

        Debug.Log("Current Order Cup Size: " + currentOrder.cupSize);

        // Check if the triggered cup size matches the current order's cup size
        if (playerCupSize == currentOrder.cupSize)
        {
            Debug.Log("Correct cup!");
            CupText.text = "Correct Cup! " ;
            CupText.color = correctColor;
            cupPlaced = true;
           
            cupPlacement.cupNpcID = currentOrder.npcID; 
        }
        else
        {
            Debug.Log("Wrong cup. Try again!");
            CupText.text = "Wrong Cup! " ;
            CupText.color = wrongColor;
             
            cupPlaced = false;
        }

     
    }
 
}
public void ItemPlacedTrigger(string playerItemType, int npcID)
{
    if (orders.Count > 0)
    {
        Order currentOrder = orders[0];

        // Check if the triggered item type matches the current order's item type
        if (playerItemType == currentOrder.boba || playerItemType == currentOrder.syrup || playerItemType == currentOrder.tea || playerItemType == currentOrder.cupSize)
        {
            Debug.Log("Correct item: " + playerItemType);
              if (audioSource != null && correctSound != null)
                {
                    audioSource.clip = correctSound;
                    audioSource.Play();
                }

            // Update the corresponding flag
            if (playerItemType == currentOrder.boba) bobaPlaced = true;
            else if (playerItemType == currentOrder.syrup) syrupPlaced = true;
            else if (playerItemType == currentOrder.tea) teaPlaced = true;
            
         

            // Check if all items in the order are placed correctly
            if (bobaPlaced && syrupPlaced && teaPlaced )
            {
                Debug.Log("Order complete for Npc ID" + currentOrder.npcID);

                    CompletedOrder completedOrder = new CompletedOrder
                    {
                        
                        order = currentOrder    
                    };
                    orderText.text = "Order Complete!";
                    orders.RemoveAt(0);
                    completedOrders.Add(completedOrder);


                // Reset placed item flags
                bobaPlaced = false;
                syrupPlaced = false;
                teaPlaced = false;
                cupPlaced = false;

               

        
            }
        }
        else
        {
            Debug.Log("Wrong item. Try again!");
             if (audioSource != null && wrongSound != null)
                {
                    audioSource.clip = wrongSound;
                    audioSource.Play();
                }
        }
    }
}

public bool IsCupPlaced()
{
    return cupPlaced;
}

void OnApplicationQuit()
{
    orders.Clear();
    completedOrders.Clear();
}


void OnDisable()
{
    orders.Clear();
    completedOrders.Clear();
}

}
