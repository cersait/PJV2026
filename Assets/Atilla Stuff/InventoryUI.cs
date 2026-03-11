using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour //Inventorys UI
{
    // Gjort av Aiden o Atilla Tokat
    public List<Image> itemIcons = new List<Image>();

    void Start()
    {
        if (InventoryManager.Instance != null)
            Refresh(InventoryManager.Instance.carriedItems);
    }

    public void Refresh(List<Item> items) //adds the itemdatas sprite to the inventory UI, and can be used by the dragdropitem script
    {
        for (int i = 0; i < itemIcons.Count; i++)
        {
            if (i < items.Count)
            {
                itemIcons[i].gameObject.SetActive(true);
                itemIcons[i].sprite = items[i].icon;

                // Pass the actual Item data to the Drag script
                DragDropItem dragScript = itemIcons[i].GetComponent<DragDropItem>();
                if (dragScript != null)
                {
                    dragScript.SetItem(items[i]);
                    dragScript.ResetToHome();
                }
            }
            else
            {
                itemIcons[i].gameObject.SetActive(false);
            }
        }
    }
}