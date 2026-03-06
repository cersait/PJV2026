using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> carriedItems = new List<Item>();
    public int maxSlots = 1;

    public Item presentKeyTemplate;
    public Item pastKeyTemplate;
    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    public bool TryAddItem(Item newItem)
    {
        if (carriedItems.Count < maxSlots)
        {
            carriedItems.Add(newItem);
            UpdateUIInScene();
            return true;
        }
        return false;
    }

    public void RemoveItem(Item itemToRemove)
    {
        if (carriedItems.Contains(itemToRemove))
        {
            carriedItems.Remove(itemToRemove);
            UpdateUIInScene();
        }
    }

    public void Convert(Item itemToConvert)
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

    public void UpdateUIInScene()
    {
        InventoryUI currentUI = Object.FindFirstObjectByType<InventoryUI>();
        if (currentUI != null) currentUI.Refresh(carriedItems);
    }
}