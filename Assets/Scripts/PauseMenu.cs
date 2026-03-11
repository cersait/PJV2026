using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    // ´Gjort av Aiden
    public static bool isPaused = false;
    public static bool isInDialogue = false;
    [SerializeField] private GameObject pauseMenuUI;

    void Update()
    {
        // Om spelaren pratar med NPC så kan man inte pausa spelet 
        if (PauseMenu.isInDialogue) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        // Man trycker på knappet för att fortsätta spelet
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        // trycker man esc så pausar spelet 
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitGame()
    {
        // tryckar man på knappen så stänger man av spelet helt
        Application.Quit();
        Debug.Log("Game Quit"); 
    }

    
}