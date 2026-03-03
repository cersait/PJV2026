using UnityEngine;
using static Interfaces;

public class ItemPickup : MonoBehaviour, IInteractable
{
    [SerializeField] private string itemID;

    public void Interact(GameObject interactor)
    {
        Inventory inventory = interactor.GetComponent<Inventory>();

        if (inventory != null)
        {
            inventory.AddItem(itemID);
            Destroy(gameObject);
        }
    }
}