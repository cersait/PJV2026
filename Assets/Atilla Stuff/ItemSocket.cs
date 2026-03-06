using UnityEngine;

public class ItemSocket : MonoBehaviour
{
    // gjort av Atilla Tokat
    [Header("Slow Door")]
    public ItemType requiredTypeCog;
    public DoorManager doorManager;
    public GameObject visualGear; // The 3D model that appears when placed
    private bool isFilled = false;

    [Header("Key/Item Switcher")]
    public ItemType requiredTypeKey1;
    public ItemType requiredTypeKey2;

    [Header("Insta Door")]
    public ItemType requiredTypeKey;
    public GameObject Door;

    [Header("Moving Object")]
    public ItemType requiredTypeBattery;
    public MovingPlatform MoveObject;
    public GameObject anchor;

    public bool ActivateCog(Item incomingItem)
    {
        if (isFilled) return false;

        if (incomingItem.type == requiredTypeCog)
        {
            isFilled = true;

            if (visualGear != null) visualGear.SetActive(true);

            InventoryManager.Instance.RemoveItem(incomingItem);

            if (doorManager != null) doorManager.GearPlaced();

            return true;
        }
        return false;
    }

    public bool ActivateConvert(Item itemToConvert)
    {
        if (itemToConvert.type == requiredTypeKey1)
        {
            InventoryManager.Instance.Convert(itemToConvert);

            return true;
        }

        else if (itemToConvert.type == requiredTypeKey2)
        {
            InventoryManager.Instance.Convert(itemToConvert);

            return true;
        }
        return false;

    }
    public bool ActivateKey(Item itemKey)
    {
        if (isFilled) return false;

        if (itemKey.type == requiredTypeKey)
        {
            InventoryManager.Instance.RemoveItem(itemKey);

            Destroy(Door);

            return true;
        }
        return false;
    }
    public bool ActivateMoving(Item itemBattery)
    {
        if (isFilled) return false;

        if (itemBattery.type == requiredTypeBattery)
        {
            InventoryManager.Instance.RemoveItem(itemBattery);

            MoveObject.enabled = true;

            Destroy(anchor);

            return true;
        }
        return false;
    }
}
