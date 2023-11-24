// SelectableItem.cs
using UnityEngine;

public class SelectableItem : MonoBehaviour
{
    public enum ItemType { Cup, Syrup, Boba, Tea };
    public ItemType itemType;

    public Order.CupSize cupSize; // Added cupSize

}
