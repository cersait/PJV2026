using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Gjort av Aiden
    public static Inventory Instance;
    private static List<string> items = new List<string>();

   /* private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // tar sönder om det finns mer än ett
        }
    }*/

    public void AddItem(string itemID)
    {
       // om det har Item ID kommer det sparas i inventory
        if (!items.Contains(itemID))
        {
            items.Add(itemID);
            Debug.Log(itemID + " added.");
        }
    }

    public bool HasItem(string itemID)
    {
        return items.Contains(itemID);
    }

    public void RemoveItem(string itemID)
    {
        // när item blir används så tars det bort från inventory
        if (items.Contains(itemID))
        {
            items.Remove(itemID);
        }
    }
}