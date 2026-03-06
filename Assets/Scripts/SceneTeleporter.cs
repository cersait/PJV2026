using UnityEngine;
using UnityEngine.SceneManagement;
using static Interfaces;

public class SceneTeleporter : MonoBehaviour, IInteractable
{

    // Gjort av Aiden
    [SceneDropdown]
    public string sceneToLoad;

    public void Interact(GameObject interactor)
    {
        //teleporterar till vald scen 
        Debug.Log("Loading scene: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}