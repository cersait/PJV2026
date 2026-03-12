using UnityEngine;

public class PickupToUI : MonoBehaviour //picks up items to inventory
{
    // gjort av Atilla Tokat
    public Item itemData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Checks if it's the player that interacting
        if (other.CompareTag("Player"))
        {
            if (InventoryManager.Instance != null && itemData != null)
            {
                //tries to add the item to inventory based on the itemdata
                if (InventoryManager.Instance.TryAddItem(itemData))
                {
                    Debug.Log(itemData.itemName + " picked up!");
                    Destroy(gameObject); //Removes the item from the world
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