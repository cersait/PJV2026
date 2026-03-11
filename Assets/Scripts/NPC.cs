using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using static Interfaces;

public class NPC : MonoBehaviour, IInteractable
{

    // Gjort Av Aiden 
    public NPCDialogue dialogueData;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;
    public Image portraitImage;

    private int dialogueIndex = 0;
    private bool isTyping = false;
    private bool isDialogueActive = false;
    private Coroutine typingCoroutine;

    public bool CanInteract() => !isDialogueActive;

    public void Interact(GameObject interactor)
    {

        
        if (dialogueData == null) return;

        if (!isDialogueActive)
        {
            // Tryck F(Interact knappen) för att starta dialogue, genom att öppna dialogue panel
            StartDialogue(interactor);
            return;
        }

        // Om man trycker F medans text blir fortfarande skriven ska full text visas istället för att vänta
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;

            // Om det är sista linjen så slutar dialoguen och stänger av dialogue panel
            if (dialogueIndex == dialogueData.dialogueLines.Length - 1)
            {
                EndDialogue();
            }

            return;
        }

        // om IsTyping falsk så byter det till nästa linjen
        dialogueIndex++;

        // Kollar om det är det sista linjen av dialogue 
        if (dialogueIndex >= dialogueData.dialogueLines.Length)
        {
            EndDialogue();
        }
        else
        {
            typingCoroutine = StartCoroutine(TypeLine());
        }
    }
    
    private void StartDialogue(GameObject interactor)
    {
        // Hittar pause meny och stänger av det så man kan inte gå i det
        PauseMenu pauseMenu = FindObjectOfType<PauseMenu>();
        if (pauseMenu != null)
        {
            pauseMenu.enabled = false;
        }
        isDialogueActive = true;
        dialogueIndex = 0;

        // Visa allt NPC Info som namn och bild på NPC 
        nameText.SetText(dialogueData.npcName);
        portraitImage.sprite = dialogueData.npcPortrait;
        dialoguePanel.SetActive(true);
        PauseMenu.isInDialogue = true;

        // Så spelaren inte går medans de pratar med NPC
        PlayerMovement player = interactor.GetComponent<PlayerMovement>();
        if (player != null) player.StopMovement();

        // börjar skriva första linjen av text
        typingCoroutine = StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText("");
        // vad ska skrivas i text lådan och vilka text ska skrivas,
        string line = dialogueData.dialogueLines[dialogueIndex];
        foreach (char letter in line)
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(dialogueData.typingSpeed);
        }
        
        isTyping = false;
      
    }

    public  void EndDialogue()
    {
        // slut dialogue så det stänger av allt med dialogue och sätter på pause meny
        PauseMenu pauseMenu = FindObjectOfType<PauseMenu>();
        if (pauseMenu != null)
        {
            pauseMenu.enabled = true;
        }
        StopAllCoroutines();
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
        PauseMenu.isInDialogue = false;
    }
}