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
            // First press: start dialogue
            StartDialogue(interactor);
            return;
        }

        // If typing, finish current line immediately
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;

            // If this is the last line, close dialogue immediately
            if (dialogueIndex == dialogueData.dialogueLines.Length - 1)
            {
                EndDialogue();
            }

            return;
        }

        // Not typing: move to next line
        dialogueIndex++;

        // Check if we've reached the end
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

        PauseMenu pauseMenu = FindObjectOfType<PauseMenu>();
        if (pauseMenu != null)
        {
            pauseMenu.enabled = false;
        }
        isDialogueActive = true;
        dialogueIndex = 0;

        // Show NPC info
        nameText.SetText(dialogueData.npcName);
        portraitImage.sprite = dialogueData.npcPortrait;
        dialoguePanel.SetActive(true);
        PauseMenu.isInDialogue = true;

        // Stop player immediately
        PlayerMovement player = interactor.GetComponent<PlayerMovement>();
        if (player != null) player.StopMovement();

        // Start typing first line
        typingCoroutine = StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText("");

        string line = dialogueData.dialogueLines[dialogueIndex];
        foreach (char letter in line)
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(dialogueData.typingSpeed);
        }

        isTyping = false;
        // Do NOT auto-close; wait for player to press F
    }

    public  void EndDialogue()
    {
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