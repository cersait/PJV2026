using UnityEngine;
using TMPro;

public class KeypadPuzzle : MonoBehaviour
{
    [SerializeField] private TMP_Text codeText;
    [SerializeField] private string correctCode = 482;
    [SerializeField] private GameObject doorToUnlock;
}
