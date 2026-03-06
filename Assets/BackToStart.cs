using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToStart : MonoBehaviour
{
    [SerializeField] int targetScene;
    private void OnDisable()
    {
        SceneManager.LoadScene(0);
    }
}
