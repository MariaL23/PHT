using UnityEngine;
using UnityEngine.VFX;

public class MagicTest : MonoBehaviour
{
    public VisualEffect visualEffect;

    private void Start()
    {
        // Make sure the Visual Effect is assigned
        if (visualEffect == null)
        {
            Debug.LogError("Visual Effect is not assigned to the script!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered has a specific tag (e.g., "Player")
        if (other.CompareTag("Player"))
        {
            // Start the visual effect
            if (visualEffect != null)
            {
                visualEffect.Play();
            }
            else
            {
                Debug.LogError("Visual Effect is not assigned to the script!");
            }
        }
    }
}

