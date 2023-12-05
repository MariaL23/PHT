using UnityEngine;

public class TagTrigger: MonoBehaviour
{

     public string Tag = "CupTag";
    public string ObjectName = "TeaObject";
    private void OnTriggerEnter(Collider other)
    {    
       
        // Check if the collided object has the "CupTag" tag
        if (other.gameObject.CompareTag(Tag))
        {
            // Attempt to find the tea object inside the cup
            Transform teaObject = other.transform.Find(ObjectName);

            // If the tea object is found, activate it
            if (teaObject != null)
            {
                teaObject.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogWarning(ObjectName + "not found inside the cup!");
            }
        }
    }
}
