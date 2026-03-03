using UnityEngine;
using static Interfaces;

public class TempDoor : Door, IInteractable
{
    new public void Interact(GameObject interactor)
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

    void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
