using UnityEngine;

public class TeaPouringController : MonoBehaviour
{
    public GameObject teaObject; // Reference to the tea object that will be poured
    public float tiltAngleMin = 30f; // Minimum tilt angle to activate pouring
    public float tiltAngleMax = 90f; // Maximum tilt angle to activate pouring

    private void Update()
    {
        // Check the z-axis rotation of the tea pot
        float currentRotation = transform.eulerAngles.z;

        // Adjust rotation to be in the range [0, 360)
        currentRotation = (currentRotation + 360f) % 360f;

        // Check if the tea pot is tilted within the desired angle range
        if (currentRotation > tiltAngleMin && currentRotation < tiltAngleMax)
        {
            // Activate the tea pouring object
            teaObject.SetActive(true);
        }
        else
        {
            // Deactivate the tea pouring object if not tilted within the desired range
            teaObject.SetActive(false);
        }
    }
}
