using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool hasKey = false;   // Example item

    public void AddKey()
    {
        hasKey = true;
        Debug.Log("Key collected!");
    }

    public void UseKey()
    {
        hasKey = false;
        Debug.Log("Key used!");
    }
}