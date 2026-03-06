using UnityEngine;
using static Interfaces;
public class KeypadInteract : MonoBehaviour, IInteractable
{

    // Gjord av Aiden
    [SerializeField] private GameObject keypadUI;


    public void Interact(GameObject interactor)
    {
        keypadUI.SetActive(true);
        Time.timeScale = 0;
    }
}
