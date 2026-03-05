using UnityEngine;
using UnityEngine.SceneManagement;
using static Interfaces;

public class SceneTeleporter : MonoBehaviour, IInteractable
{
    [SceneDropdown]
    public string sceneToLoad;

    public void Interact(GameObject interactor)
    {
        Debug.Log("Loading scene: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}