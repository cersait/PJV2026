using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    // En lista med de 3 ikonerna i ditt UI
    public List<GameObject> itemIcons = new List<GameObject>();

    public bool TryAddItem()
    {
        // Gå igenom alla slots och hitta den första som är ledig (inactive)
        foreach (GameObject icon in itemIcons)
        {
            if (!icon.activeSelf)
            {
                icon.SetActive(true);
                Debug.Log("Föremål tillagt i en ledig slot!");
                return true; // Lyckades lägga till!
            }
        }

        Debug.Log("Inventoryt är fullt!");
        return false; // Misslyckades (fullt)
    }
}
