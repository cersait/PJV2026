using UnityEngine;
using UnityEngine.SceneManagement;
using static Interfaces;

public class SceneTeleporter : MonoBehaviour, IInteractable
{
    [SceneDropdown]
    public string sceneToLoad;

    public void Interact(GameObject interactor)
    {
        DontDestroyOnLoad(interactor);
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneToLoad);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        SpawnPoint spawn = FindObjectOfType<SpawnPoint>();

        if (player != null && spawn != null)
        {
            player.transform.position = spawn.transform.position;
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}