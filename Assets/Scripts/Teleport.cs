using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject nextPortal;
    private bool playerIsOverlapping = false;
    private Transform playerTransform;

    void Update()
    {
        // Vi kollar efter knapptryck varje bildruta, men bara om spelaren står i portalen
        if (playerIsOverlapping && Input.GetKeyDown(KeyCode.F))
        {
            playerTransform.position = nextPortal.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsOverlapping = true;
            playerTransform = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsOverlapping = false;
            Debug.Log("Spelaren lämnade portalen");
        }
    }
}
