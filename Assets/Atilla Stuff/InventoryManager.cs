using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Sprite> carriedItemSprites = new List<Sprite>(); // Sparar bilderna
    public int maxSlots = 3;

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    public bool TryAddItem(Sprite itemSprite)
    {
        if (carriedItemSprites.Count < maxSlots)
        {
            carriedItemSprites.Add(itemSprite); // Spara bilden
            UpdateUIInScene();
            return true;
        }
        return false;
    }

    public void RemoveItem(Sprite itemSprite)
    {
        carriedItemSprites.Remove(itemSprite); // Ta bort just denna bild
        UpdateUIInScene();
    }

    public void UpdateUIInScene()
    {
        InventoryUI currentUI = Object.FindFirstObjectByType<InventoryUI>();
        if (currentUI != null) currentUI.Refresh(carriedItemSprites);
    }
}
