// OrderManager script
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
    }

    public List<string> cupSizes = new List<string>();
    public List<string> bobas = new List<string>();
    public List<string> sirups = new List<string>();
    public List<string> teas = new List<string>();

    public TextMeshPro orderText;
    
    public TextMeshPro NextorderText;
 
    public List<Order> orders = new List<Order>();

    // Call this method when an NPC hits a trigger


        string GetRandomItem(List<string> itemList)
    {
        int randomIndex = Random.Range(0, itemList.Count);
        return itemList[randomIndex];
    }
public void NPCReachedTrigger()
{
    Order newOrder = new Order();
    newOrder.cupSize = GetRandomItem(cupSizes);
    newOrder.boba = GetRandomItem(bobas);
    newOrder.syrup = GetRandomItem(sirups);
    newOrder.tea = GetRandomItem(teas);

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

    Debug.Log("Current order: " + newOrder.cupSize + ", " + newOrder.boba + ", " + newOrder.syrup + ", " + newOrder.tea);
    // Do something with the current order, like displaying it to the player or initiating a task.
}

    // Call this method when the player places a cup on a trigger
   public void CupPlacedTrigger(string playerCupSize)
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
        }
        else
        {
            Debug.Log("Wrong cup. Try again!");
        }

        // Remove the completed order from the list
        orders.RemoveAt(0);

        // Generate a new order for the next round
        NPCReachedTrigger();
    }
    else
    {
        Debug.Log("No current orders");
    }
}
      private bool cupPlaced = false;
  private bool bobaPlaced = false;
    private bool syrupPlaced = false;
    private bool teaPlaced = false;
   public void ItemPlacedTrigger(string playerItemType)
    {
        if (orders.Count > 0)
        {
            Order currentOrder = orders[0];

            // Check if the triggered item type matches the current order's item type
            if (playerItemType == currentOrder.boba || playerItemType == currentOrder.syrup || playerItemType == currentOrder.tea || playerItemType == currentOrder.cupSize)
            {
                Debug.Log("Correct item: " + playerItemType);

                // Update the corresponding flag
                if (playerItemType == currentOrder.boba) bobaPlaced = true;
                else if (playerItemType == currentOrder.syrup) syrupPlaced = true;
                else if (playerItemType == currentOrder.tea) teaPlaced = true;
                else if (playerItemType == currentOrder.cupSize) cupPlaced = true;

                // Check if all items in the order are placed correctly
                if (bobaPlaced && syrupPlaced && teaPlaced && cupPlaced)
                {
                    Debug.Log("Complete order is correct!");

                    // Reset placed item flags
                    bobaPlaced = false;
                    syrupPlaced = false;
                    teaPlaced = false;
                    cupPlaced = false;

                    // Remove the completed order from the list
                    orders.RemoveAt(0);

                    // Generate a new order for the next round
                    NPCReachedTrigger();
                }
            }
            else
            {
                Debug.Log("Wrong item. Try again!");
            }
        }
        else
        {
            Debug.Log("No current orders");
        }
    }

}
