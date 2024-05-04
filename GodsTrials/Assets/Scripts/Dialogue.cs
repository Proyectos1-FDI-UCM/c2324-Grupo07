using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject ZHead;
    [SerializeField] private GameObject HHead;
    [SerializeField] private GameObject Square1;
    [SerializeField] private GameObject Square2;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject Collider;
    [SerializeField] private GameObject ColliderExplicativo;
    private float typingTime = 0.05f;

    private bool didDialogueStart = false;
    private int lineIndex = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("dialog");
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!didDialogueStart)
            {
                HUD.SetActive(false);
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                Debug.Log("NEXTdialog");
                NextDialogueLine();
            }

        }

    }

    private void StartDialogue()
    {
        Square1.SetActive(true);
        Square2.SetActive(true);
        ZHead.SetActive(true);
        Debug.Log("start dialog");
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        //StartCoroutine(ShowLine());
        Time.timeScale = 0;
        ShowLineTimeless();
    }
    private void NextDialogueLine()
    {
        
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            if(lineIndex==1)
            {
                ZHead.SetActive(false); 
                HHead.SetActive(true);
                //StartCoroutine(ShowLine());
                ShowLineTimeless();
            }

            else if (lineIndex==2)
            {
                ZHead.SetActive(true);
                HHead.SetActive(false);
                //StartCoroutine(ShowLine());
                ShowLineTimeless();
            }

            else if (lineIndex == 3)
            {
                ZHead.SetActive(false);
                HHead.SetActive(true);
                //StartCoroutine(ShowLine());
                ShowLineTimeless();
            }

            else if (lineIndex == 4)
            {
                ZHead.SetActive(true);
                HHead.SetActive(false);
                //StartCoroutine(ShowLine());
                ShowLineTimeless();
            }

        }
        else
        {
            Square1.SetActive(false);
            Square2.SetActive(false);
            ZHead.SetActive(false);
            HHead.SetActive(false);
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            HUD.SetActive(true);
            Collider.SetActive(false);
            ColliderExplicativo.SetActive(true);
            Time.timeScale = 1;
        }
    }
    private IEnumerator ShowLine()
    {
        Debug.Log("show line coroutine");
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            Debug.Log("foreach");
            yield return new WaitForSeconds(typingTime);
            dialogueText.text += ch;
        }

        int tiempoEntreLines = 3;
        yield return new WaitForSeconds(tiempoEntreLines);
        NextDialogueLine();
    }

    private void ShowLineTimeless(){
        dialogueText.text = dialogueLines[lineIndex];
    }

    void Update()
    {
        if (Input.anyKeyDown && didDialogueStart)
        {
            NextDialogueLine();
        }
    }
}
