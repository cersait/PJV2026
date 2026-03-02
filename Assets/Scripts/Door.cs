using UnityEngine;
using static Interfaces;

public class Door : MonoBehaviour, IInteractable 
{
    public string requiredKeyID;  // Example: "RedKey"

    public void Interact(GameObject interactor)
    {
        Inventory inventory = interactor.GetComponent<Inventory>();

        if (inventory != null && inventory.HasItem(requiredKeyID))
        {
            inventory.RemoveItem(requiredKeyID);
            OpenDoor();
        }
        else
        {
            Debug.Log("You need the correct key!");
        }
    }

    private void OpenDoor()
    {
        Debug.Log("Door opened!");
        gameObject.SetActive(false);
    }
}