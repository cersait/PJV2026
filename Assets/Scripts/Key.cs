using UnityEngine;
using static Interfaces;

public class Key : MonoBehaviour, IInteractable
{
    public string keyID;  

    public void Interact(GameObject interactor)
    {
        Inventory inventory = interactor.GetComponent<Inventory>();

        if (inventory != null)
        {
            inventory.AddItem(keyID);
            Destroy(gameObject);
        }
    }
}