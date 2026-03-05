using UnityEngine;
using static Interfaces;

public class Door : MonoBehaviour, IInteractable
{

    // Gjort av Aiden
    [SerializeField] private string requiredKeyID;  // Example: "RedKey"
    [SerializeField] private Transform teleportPoint;
    [SerializeField] private GameObject door;

    private bool isUnlocked = false;

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
        Destroy(gameObject);
    }
    public void UnlockDoor()
    {
        door.SetActive(false);
    }

  
    void teleportPlayer(GameObject player)
    {
        player.transform.position = teleportPoint.position;

    }


}