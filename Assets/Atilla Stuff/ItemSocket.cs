using UnityEngine;

public class ItemSocket : MonoBehaviour //manages interactions between item and sockets
{
    // gjort av Atilla Tokat
    [Header("Slow Door")] //If used, makes so doors open slowly with doormanager
    public ItemType requiredTypeCog;
    public DoorManager doorManager;
    public GameObject visualGear; 
    private bool isFilled = false;

    [Header("Key/Item Switcher")] //If used, converts item to another item
    public ItemType requiredTypeKey1;
    public ItemType requiredTypeKey2;

    [Header("Insta Door")] //if used, destroys door if a item is put in
    public ItemType requiredTypeKey;
    public GameObject Door;

    [Header("Moving Object")] //if used, enables platforms to move
    public ItemType requiredTypeBattery;
    public MovingPlatform MoveObject;
    public GameObject anchor;

    public bool ActivateCog(Item incomingItem) //activates the door and cogwheel function 
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

    public bool ActivateConvert(Item itemToConvert) //activates the converter function
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
    public bool ActivateKey(Item itemKey) //activates the insta door function
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
    public bool ActivateMoving(Item itemBattery) //activates the moving objects function
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
