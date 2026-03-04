using UnityEngine;
using TMPro;
using Unity.Collections;
using System.Collections;
using UnityEngine.UI;
public class Talk_text : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public string[] lines;
    public float textSpeed;
    private int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tmp.text = string.Empty;
        startText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startText()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            tmp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

    }




}
