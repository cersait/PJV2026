using UnityEngine;
using static Interfaces;
public class PlayerInteract : MonoBehaviour
{

    // Gjort av Hannes, Redigerad av Aiden 
    [SerializeField] KeyCode interactKey = KeyCode.F;
    public IInteractable currentInteractable;

    // Update is called once per frame
    void Update()
    {
            // Hannes
            if (Input.GetKeyDown(interactKey))
            {
                Debug.Log("F pressed");
            }

            if (currentInteractable != null && Input.GetKeyDown(interactKey))
            {
                Debug.Log("Interacting with " + currentInteractable);
                currentInteractable.Interact(gameObject);
            }
        
      
    }
    // Aiden
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null)
        {
            currentInteractable = interactable;
        }
    }
    // Aiden
    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
        }
    }
}
