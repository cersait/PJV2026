using UnityEngine;

public class ItemSocket : MonoBehaviour
{
    public ItemType requiredType;
    public DoorManager doorManager;
    public GameObject visualGear; // The 3D model that appears when placed
    private bool isFilled = false;

    public bool Activate(Item incomingItem)
    {
        if (isFilled) return false;

        if (incomingItem.type == requiredType)
        {
            isFilled = true;

            if (visualGear != null) visualGear.SetActive(true);

            InventoryManager.Instance.RemoveItem(incomingItem);

            if (doorManager != null) doorManager.GearPlaced();

            return true;
        }
        return false;
    }
}