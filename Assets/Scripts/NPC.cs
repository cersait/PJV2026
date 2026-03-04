using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static Interfaces;
using System.Collections;

public class NPC : MonoBehaviour, IInteractable
{
    public NPCDialogue dialogueData;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;
    public Image portraitImage;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;


    public bool CanInteract()
    {
        return !isDialogueActive;
    }
   
   

    public void Interact(GameObject interactor)
    {
        if (dialogueData == null)
            return;

        if (isDialogueActive)
        {
            nextLine();
        }
        else
        {
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        Debug.Log("START DIALOGUE RUNNING");
        isDialogueActive = true;
        dialogueIndex = 0;

        nameText.SetText(dialogueData.npcName);
        portraitImage.sprite = dialogueData.npcPortrait;

        dialoguePanel.SetActive(true);
        PauseMenu.isInDialogue = true;
        PlayerMovement player = FindObjectOfType<PlayerMovement>();

        if (player != null)
        {
            player.StopMovement();
        }

        StartCoroutine(TypeLine());
    }

    void nextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }
        else
        {
            dialogueIndex++;
            if (dialogueIndex < dialogueData.dialogueLines.Length)
                StartCoroutine(TypeLine());
            else
                EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText("");
        foreach(char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(dialogueData.typingSpeed);
        }

        isTyping = false;

        if (dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            yield return new WaitForSecondsRealtime(dialogueData.autoProgressDelay);
            nextLine();
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);
        PauseMenu.isInDialogue = false;
    }
    
}
