using UnityEngine;
using static Interfaces;
public class PlayerInteract : MonoBehaviour
{
    [SerializeField] KeyCode interactKey = KeyCode.F;
    public IInteractible currentInteractible;

    // Update is called once per frame
    void Update()
    {
        if(currentInteractible != null && Input.GetKeyDown(interactKey))
        {
            currentInteractible.Interact();
        }
    }
}
