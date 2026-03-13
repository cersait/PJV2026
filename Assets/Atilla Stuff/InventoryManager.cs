using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour //manages the inventory based on activity
{
    // gjort av Atilla Tokat
    public static InventoryManager Instance;
    public List<Item> carriedItems = new List<Item>();
    public int maxSlots = 1;

    public Item presentKeyTemplate;
    public Item pastKeyTemplate;
    private void Awake() //saves the inventory scene to scene
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    public bool TryAddItem(Item newItem) //tries to add item to inventory
    {
        if (carriedItems.Count < maxSlots)
        {
            carriedItems.Add(newItem);
            UpdateUIInScene();
            return true;
        }
        return false;
    }

    public void RemoveItem(Item itemToRemove) //removes item from inventory
    {
        if (carriedItems.Contains(itemToRemove))
        {
            carriedItems.Remove(itemToRemove);
            UpdateUIInScene();
        }
    }

    public void Convert(Item itemToConvert) //converts item if dropped into a itemswitcher
    {
        int index = carriedItems.IndexOf(itemToConvert);

        // If the item isn't in our inventory, we can't convert it
        if (index == -1) return;

        if (itemToConvert.type == ItemType.PresentKey)
        {
            carriedItems[index] = pastKeyTemplate;
            Debug.Log("Key -> Oldkey");
        }
        else if (itemToConvert.type == ItemType.PastKey)
        {
            carriedItems[index] = presentKeyTemplate;
            Debug.Log("Oldkey -> Key");
        }

        UpdateUIInScene();
    }

    public void UpdateUIInScene() //updates the scenes UI
    {
        InventoryUI currentUI = Object.FindFirstObjectByType<InventoryUI>();
        if (currentUI != null) currentUI.Refresh(carriedItems);
    }

    public void ClearInventory()
    {
        carriedItems.Clear();
    }
}