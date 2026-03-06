using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneScaler : MonoBehaviour
{

    //Not Used
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
            transform.localScale = new Vector3(3.013816f, 2.840733f, 1f);
        }
    }
}
