using UnityEngine;

public class PickupToUI : MonoBehaviour
{
    private InventoryManager inventory;

    void Start()
    {
        // Hitta inventory-scriptet i scenen
        inventory = Object.FindFirstObjectByType<InventoryManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Försök lägga till i inventory
            if (inventory != null && inventory.TryAddItem())
            {
                // Om det fanns plats: Ta bort från marken
                Destroy(gameObject);
            }
            else
            {
                // Om det var fullt: Gör inget (eller visa ett meddelande)
                Debug.Log("Kan inte plocka upp, inventoryt är fullt!");
            }
        }
    }
}
