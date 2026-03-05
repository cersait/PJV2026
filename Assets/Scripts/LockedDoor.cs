using UnityEngine;
using static Interfaces;

public class LockedDoor : MonoBehaviour, IInteractable
{
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
        isLocked = startsLocked;
    }

    public void Interact(GameObject interactor)
    {
        Inventory inventory = interactor.GetComponent<Inventory>();

        if (isLocked)
        {
            if (inventory != null && inventory.HasItem(requiredKeyID))
            {
                UnlockDoor(inventory);
            }
            else
            {
                Debug.Log("Door is locked.");
                return;
            }
        }

        Teleport(interactor);
    }

    void UnlockDoor(Inventory inventory)
    {
        isLocked = false;
        inventory.RemoveItem(requiredKeyID);

        Debug.Log("Door unlocked!");
    }

    void Teleport(GameObject player)
    {
        if (!canTeleport) return;

        if (connectedDoor != null && connectedDoor.spawnPoint != null)
        {
            player.transform.position = connectedDoor.spawnPoint.position;

            connectedDoor.BlockTeleport();
        }

    }

    void BlockTeleport()
    {
        canTeleport = false;
        Invoke(nameof(ResetTeleport), 0.5f);
    }

    void ResetTeleport()
    {
        canTeleport = true;
    }
}