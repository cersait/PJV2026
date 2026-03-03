using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public List<Image> itemIcons = new List<Image>(); // Ändra till Image istället för GameObject

    void Start()
    {
        if (InventoryManager.Instance != null)
            Refresh(InventoryManager.Instance.carriedItemSprites);
    }

    public void Refresh(List<Sprite> sprites)
    {
        // Säkerhetskoll 1: Har vi glömt dra in ikoner i Inspectorn?
        if (itemIcons == null || itemIcons.Count == 0)
        {
            Debug.LogError("Du har inte dragit in några Images i InventoryUI på " + gameObject.name);
            return;
        }

        for (int i = 0; i < itemIcons.Count; i++)
        {
            // Säkerhetskoll 2: Är en specifik slot i listan tom?
            if (itemIcons[i] == null) continue;

            if (i < sprites.Count)
            {
                itemIcons[i].sprite = sprites[i];
                itemIcons[i].gameObject.SetActive(true);

                // Viktigt: Om du använder DragDropItem, se till att den också 
                // vet vilken startposition den har nu när den aktiveras
                itemIcons[i].GetComponent<CanvasGroup>().alpha = 1f;
            }
            else
            {
                itemIcons[i].gameObject.SetActive(false);
            }
        }
    }

}
