using UnityEngine;
using UnityEngine.SceneManagement;
using static Interfaces;

public class SceneTeleporter : MonoBehaviour, IInteractable
{

    // Aiden
    [SceneDropdown]
    public string sceneToLoad;
    // Genom interface så byter scen med den som man har valt
    public void Interact(GameObject interactor)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneToLoad);
    }
    // när scenen loadar så letar efter spelaren och spawnpoint och spawnar spelaren på spawnpoints position
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