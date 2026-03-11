using UnityEngine;
using TMPro;

public class KeypadPuzzle : MonoBehaviour
{

    // Gjord av Aiden 
    [SerializeField] private TMP_Text codeText;
    [SerializeField] private string correctCode = "452";
    [SerializeField] private GameObject doorToUnlock;
    [SerializeField] private GameObject keyPad;

    private string currentCode = "";
    void Update()
    {
        // Press ESC to exit keypad
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitKeypad();
        }
    }
    // Att lägga till alla knappars variabel till deras number t.ex, knapp 1 ska skriva 1 när man trycker på det
    public void AddDigits(string digit)
    {
        if (currentCode.Length >= 3) return;

        currentCode += digit;
        codeText.text = currentCode;
        
    }
    // När man trycker på det så allt du skrev raderas
    public void ClearCode()
    {
        currentCode = "";
        codeText.text="";

    }

    // man trycker det här knappen så kollar det om du fick rätt kod, om du fick det så öppnar dörren annars tar de bort koden du skrev och du måste skriva ett nytt
    public void CheckCode()
    {
        if (currentCode == correctCode)
        {
            doorToUnlock.GetComponent<PuzzleDoor>().UnlockDoor();
            keyPad.SetActive(false);
            Time.timeScale = 1;
            PauseMenu.isInDialogue = false; // allow pause again
        }
        else
        {
            Debug.Log("Wrong Code");

            currentCode = "Wrong code";
            ClearCode();

        }
    }
    // Om du inte har koden så lämna man med esc
    void ExitKeypad()
    {
        keyPad.SetActive(false);
        Time.timeScale = 1;
        PauseMenu.isInDialogue = false;
        ClearCode();
    }



}
