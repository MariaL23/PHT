using UnityEngine;
using UnityEngine.SceneManagement;

public class PaymentSystem : MonoBehaviour
{
   public int totalPayment = 0;

    public int winAmount = 200;
    
    void Update()
    {
        if (totalPayment >= winAmount)
        {
            Debug.Log("Earnings = " + totalPayment + "You win!");
            // Load the win scene
           // SceneManager.LoadScene(2);
        }
    }

    // Method to add payment amount
    public void AddPayment(int amount)
    {
        totalPayment += amount;
        Debug.Log("Payment added: " + amount + ". Total payment: " + totalPayment);

   
    }
}