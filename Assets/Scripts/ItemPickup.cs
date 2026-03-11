using UnityEngine;
using static Interfaces;

public class ItemPickup : MonoBehaviour, IInteractable
{

    // Gjort av Aiden
    [SerializeField] private string itemID;

    public void Interact(GameObject interactor)
    {
        // Använd F för att plocka upp saker 
        Inventory inventory = interactor.GetComponent<Inventory>();

        if (inventory != null)
        {
            // tar in i inventory
            inventory.AddItem(itemID);
            Destroy(gameObject);
        }
    }
}