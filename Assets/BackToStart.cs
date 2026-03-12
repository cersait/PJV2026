using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToStart : MonoBehaviour
{
    [SerializeField] RectTransform fadeToBlack;
    private void OnDisable()
    {
        SceneManager.LoadScene(0);
    }
}
