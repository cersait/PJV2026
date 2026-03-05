using UnityEngine;
using TMPro;

public class KeypadPuzzle : MonoBehaviour
{
    [SerializeField] private TMP_Text codeText;
    [SerializeField] private string correctCode = "452";
    [SerializeField] private GameObject doorToUnlock;

    private string currentCode = "";

    public void AddDigits(string digit)
    {
        if (currentCode.Length >= 3) return;

        currentCode += digit;
        codeText.text = currentCode;
        
    }

    public void ClearCode()
    {
        currentCode = "";
        codeText.text="";

    }
    public void CheckCode()
    {
        if (currentCode == correctCode)
        {
            doorToUnlock.GetComponent<PuzzleDoor>().UnlockDoor();
            gameObject.SetActive(false);
        }
        else
        {
            currentCode = "Wrong code";
            ClearCode();

        }
    }

}
