using UnityEngine;
using static Interfaces;

public class Key : MonoBehaviour, IInteractable
{
    [SerializeField] private string keyID;  

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