using System.IO.Enumeration;
using UnityEngine;


[CreateAssetMenu(fileName = "NewNPCDialogue", menuName = "NPC Dialogue")]
public class NPCDialogue : ScriptableObject
{
    // Gjort av Aiden

    // Information för NPC som Namn och deras portrait när man pratar med dom, det också fixas alla dialog.
    public string npcName;
    public Sprite npcPortrait;
    public string[] dialogueLines;
    public bool[] autoProgressLines;
    public float autoProgressDelay = 1.5f;
    public float typingSpeed = 0.05f;
   
}
