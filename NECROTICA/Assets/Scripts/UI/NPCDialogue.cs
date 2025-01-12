using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public int numberOfLines = 0;
    private int index = 0;
    public float dialogueSpeed;

    public GameObject dialogue;

    private bool startDialogue = true;
    private bool isWriting;


    private void Update()
{
    if (!isWriting && Input.GetKeyDown(KeyCode.Space))
    {
        if (startDialogue)
        {
            dialogue.SetActive(true);
            startDialogue = false;
            StartCoroutine(WriteLines());
        }
        else
        {
            StopAllCoroutines();
            isWriting = false;
            NextLine();
        }
    }
}

    private void NextLine()
    {
        if(index <= lines.Length - 1)
        {
            dialogueText.text = "";
            StartCoroutine(WriteLines());
        }

        else
        {
            index = 0;
            dialogue.SetActive(false);
            startDialogue = true;
        }
    }

    IEnumerator WriteLines()
    {
        isWriting = true;
        foreach (char character in lines[index].ToCharArray())
        {
            dialogueText.text += character;
            AudioManager.instance.Play("Voice");
            yield return new WaitForSeconds(dialogueSpeed);
        }
        isWriting = false;
        index++;
        yield return null;
    }
}