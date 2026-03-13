using Unity.VisualScripting;
using UnityEngine;

public class BeatGameCheck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InventoryManager mangerCheck = FindFirstObjectByType<InventoryManager>();
        if(mangerCheck != null)
        {
            mangerCheck.ClearInventory();
        }
        TimeController.isPresent = true;
    }
}
