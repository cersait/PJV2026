using UnityEngine;
using static Interfaces;

public class LockedDoor : MonoBehaviour, IInteractable
{

    // Gjort av Aiden
    [Header("Door Settings")]
    [SerializeField] private LockedDoor connectedDoor;
    [SerializeField] private string requiredKeyID = "";
    [SerializeField] private bool startsLocked = false;

    [Header("Teleport Settings")]
    [SerializeField] private Transform spawnPoint;

    private bool isLocked;
    private bool canTeleport = true;

    private void Start()
    {
        //Om startslocked är sant så är den låst i början, annars är det öpen.
        isLocked = startsLocked;
    }

    public void Interact(GameObject interactor)
    {
        // Får inventery för att veta om man har nyckeln eller inte
        Inventory inventory = interactor.GetComponent<Inventory>();
        // Om låst så checkar det om du har nyckeln eller inte och om du har inte så gör det inget men du har det så använder Unlockdoor)
        if (isLocked)
        {
            if (inventory != null && inventory.HasItem(requiredKeyID))
            {
                UnlockDoor(inventory);
            }
            else
            {
                // dörren är låst
                Debug.Log("Door is locked.");
                return;
            }
        }
        // Man går till nästa rummet
        Teleport(interactor);
    }

    void UnlockDoor(Inventory inventory)
    {

        // Det öppnar dörren
        isLocked = false;
        inventory.RemoveItem(requiredKeyID);

        Debug.Log("Door unlocked!");
    }

    void Teleport(GameObject player)
    {
        //Teleporterar till en vald position, men om det är inte unlocked kommer det inte funkar
        if (!canTeleport) return;

        if (connectedDoor != null && connectedDoor.spawnPoint != null)
        {
            player.transform.position = connectedDoor.spawnPoint.position;

            connectedDoor.BlockTeleport();
        }

    }
    // Stängs av teleport för 0.5 sekunder
    void BlockTeleport()
    {
        canTeleport = false;
        Invoke(nameof(ResetTeleport), 0.5f);
    }
    // Lägger på teleport igen
    void ResetTeleport()
    {
        canTeleport = true;
    }
}