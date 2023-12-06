using UnityEngine;
using UnityEngine.UI;

public class TimerTrigger : MonoBehaviour
{
    public Slider timerSlider; // Reference to the UI slider
    private bool timerStarted = false;
    public float timer = 60f; // 60 seconds

    void Update()
    {
        if (timerStarted)
        {
            timer -= Time.deltaTime; // Decrease the timer by the time passed
            timerSlider.value = timer; // Update the slider value based on the timer

            if (timer <= 0)
            {
                // Perform actions when the timer reaches zero
               // Debug.Log("Timer has reached zero!");
                timerStarted = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OrderTable"))
        {
           // Debug.Log("Object entered trigger!");
            timerStarted = true; // Start the timer
        }
    }
}
