using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
   [System.Serializable]

    public enum CupSize { Small, Medium, Large };
    public enum SyrupChoice { Option1, Option2 };
    public enum BobaChoice { Option1, Option2 };
    public enum TeaChoice { Option1, Option2, Option3 };

    public CupSize cupSize;
    public SyrupChoice syrup;
    public BobaChoice boba;
    public TeaChoice tea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
