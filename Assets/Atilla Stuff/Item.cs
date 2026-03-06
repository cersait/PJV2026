using UnityEngine;
public enum ItemType { None, PresentKey, PastKey, Cogwheel, Battery, }

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    // gjort av Atilla Tokat
    public string itemName;
    public Sprite icon;
    public ItemType type; // Key, Cogwheel, etc.
}