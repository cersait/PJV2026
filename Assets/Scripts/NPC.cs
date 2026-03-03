using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static Interfaces;

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

    public void Interact()
    {
        if (dialogueData == null  && !isDialogueActive)
        {
            return;
        }
        if (isDialogueActive)
        {

        }
        else
        {

        }
    }

    public void Interact(GameObject interactor)
    {
        throw new System.NotImplementedException();
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

        nameText.SetText(dialogueData.name);
        portraitImage.sprite = dialogueData.npcPortrait;

        dialoguePanel.SetActive(true);

    }
    
}
