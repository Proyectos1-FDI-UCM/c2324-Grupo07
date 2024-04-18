using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    private float typingTime = 0.05f;

    private bool didDialogueStart = false;
    private int lineIndex = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("dialog");
        if (collision.gameObject.CompareTag("Player"))
        {
            if(!didDialogueStart) 
            {
                StartDialogue();
            }
            else if(dialogueText.text == dialogueLines[lineIndex])
            {
                Debug.Log("NEXTdialog");
                NextDialogueLine();   
            }
           
        }
        
    }

    private void StartDialogue()
    {
        Debug.Log("start dialog");
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }
    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart=false;
            dialoguePanel.SetActive(false);
        }
    }
    private IEnumerator ShowLine()
    {
        Debug.Log("show line coroutine");
        dialogueText.text = string.Empty;

        foreach(char ch in dialogueLines[lineIndex])
        {
            Debug.Log("foreach");
            yield return new WaitForSeconds(typingTime);
            dialogueText.text += ch;
        }

        int tiempoEntreLines = 3;
        yield return new WaitForSeconds(tiempoEntreLines);
        NextDialogueLine();
    }

}
