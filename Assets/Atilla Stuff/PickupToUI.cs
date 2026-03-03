using UnityEngine;

public class PickupToUI : MonoBehaviour
{
    // Drag your Item ScriptableObject (Cogwheel or Key) here in the Inspector
    public Item itemData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 1. Check if it's the player
        if (other.CompareTag("Player"))
        {
            if (InventoryManager.Instance != null && itemData != null)
            {
                // 2. Try to add the WHOLE Item object, not just a sprite
                if (InventoryManager.Instance.TryAddItem(itemData))
                {
                    Debug.Log(itemData.itemName + " picked up!");
                    Destroy(gameObject); // Remove the item from the 3D/2D world
                }
                else
                {
                    Debug.LogWarning("Inventory is full!");
                }
            }
            else if (itemData == null)
            {
                Debug.LogError("No Item Data assigned to " + gameObject.name);
            }
        }
    }
}