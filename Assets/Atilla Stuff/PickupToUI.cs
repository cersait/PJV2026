using UnityEngine;

public class PickupToUI : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Något nuddade kugghjulet: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Spelaren nuddade! Försöker lägga till i Inventory...");

            if (InventoryManager.Instance != null)
            {
                Sprite mySprite = GetComponent<SpriteRenderer>().sprite;
                if (InventoryManager.Instance.TryAddItem(mySprite))
                {
                    Destroy(gameObject);
                }
                else
                {
                    Debug.LogWarning("Inventoryt är fullt!");
                }
            }
            else
            {
                Debug.LogError("Hittade ingen InventoryManager i scenen!");
            }
        }
    }

}
