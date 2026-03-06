using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneScaler : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Anton Scene")
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (scene.name == "Korridor")
        {
            transform.localScale = new Vector3(44.46503f, 9.338171f, 1f);
        }
    }
}
