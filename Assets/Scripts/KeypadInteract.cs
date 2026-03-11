using UnityEngine;
using static Interfaces;

public class KeypadInteract : MonoBehaviour, IInteractable
{
    // Gjort av Aiden
    [SerializeField] private GameObject keypadUI;
    // att interacta med keypaden genom Interface 
    public void Interact(GameObject interactor)
    {
        // sätter på keypad och görs så man kan inte öppna pausmeny medans man är i keypad
        keypadUI.SetActive(true);
        Time.timeScale = 0;

        PauseMenu.isInDialogue = true;
    }
}
