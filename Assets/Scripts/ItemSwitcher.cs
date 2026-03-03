using UnityEngine;
using static Interfaces;

public class ItemSwitcher : MonoBehaviour, IInteractable
{
    //will update later: Hannes
    [SerializeField] string requiredItem, outputItem;

    public void Interact(GameObject interactor)
    {
        Inventory inventory = interactor.GetComponent<Inventory>();

        if (inventory.HasItem(requiredItem))
        {
            inventory.RemoveItem(requiredItem);
            inventory.AddItem(outputItem);
            print($"changed out {requiredItem} for {outputItem}");
        }
        else
        {
            print("player does not have the right item");
        }
    }
}
