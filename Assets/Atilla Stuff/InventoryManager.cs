using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> carriedItems = new List<Item>();
    public int maxSlots = 3;

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

    public void UpdateUIInScene()
    {
        InventoryUI currentUI = Object.FindFirstObjectByType<InventoryUI>();
        if (currentUI != null) currentUI.Refresh(carriedItems);
    }
}