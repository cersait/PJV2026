using UnityEngine;
using static Interfaces;
public class PlayerInteract : MonoBehaviour
{
    [SerializeField] KeyCode interactKey = KeyCode.F;
    public IInteractable currentInteractable;

    // Update is called once per frame
    void Update()
    {
        if(currentInteractable != null && Input.GetKeyDown(interactKey))
        {
            currentInteractable.Interact(gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null)
        {
            currentInteractable = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
        }
    }
}
