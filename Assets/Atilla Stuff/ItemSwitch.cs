using UnityEngine;

public class ItemSwitch : TimeObject, ITimeTravel
{
    public ItemType requiredType1;
    public ItemType requiredType2;

    public bool ActivateConvert(Item itemToConvert)
    {
        if (itemToConvert.type == requiredType1)
        {
            InventoryManager.Instance.Convert(itemToConvert);

            return true;
        }

        else if (itemToConvert.type == requiredType2)
        {
            InventoryManager.Instance.Convert(itemToConvert);

            return true;
        }
        return false;

    }
}
