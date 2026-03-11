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
        // letar efter Inventory script
        Inventory inventory = interactor.GetComponent<Inventory>();

        if (inventory != null && inventory.HasItem(requiredKeyID))
        {
            // om du interactar och har samma item med KeyID som dörren så öppnas dörren
            inventory.RemoveItem(requiredKeyID);
            OpenDoor();
        }
        else
        {
            // annars gör det inget
            Debug.Log("You need the correct key!");
        }
    }

    private void OpenDoor()
    {
        // Öppnar dörren genom att ta söder gameObject
        Debug.Log("Door opened!");
        Destroy(gameObject);
    }
    public void UnlockDoor()
    {
        // ett annatt dörr script som tar bort dörren
        door.SetActive(false);
    }

  
    void teleportPlayer(GameObject player)
    {
        // teleporterar spelaren
        player.transform.position = teleportPoint.position;

    }


}