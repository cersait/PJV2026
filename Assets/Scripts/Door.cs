using UnityEngine;

public class Door : MonoBehaviour
{
    private bool playerInRange = false;
    private Inventory playerInventory;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (playerInventory != null && playerInventory.hasKey)
            {
                playerInventory.UseKey();
                OpenDoor();
            }
            else
            {
                Debug.Log("You need a key!");
            }
        }
    }

    private void OpenDoor()
    {
        Debug.Log("Door opened!");
        gameObject.SetActive(false); // removes door
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerInventory = other.GetComponent<Inventory>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}