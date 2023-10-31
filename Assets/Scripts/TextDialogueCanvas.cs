using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDialogueCanvas : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    private float delay = 0.05f;
    private string[] fullTexts;
    private string currentFullText = "";
    private int currentSentenceIndex = 0;
    private string currentText = "";
    public bool dialogueInUse;

    public void Update()
    {
        // Skip dialogue by clearing text
       
    }

    public void SaySomething(string[] dialogue)
    {
        // Input what you want character to say
        if (!dialogueInUse)
        {
            // currentFullText = fullTexts[currentSentenceIndex];
            fullTexts = dialogue;
            dialogueInUse = true;
            StartCoroutine(ShowText());
        }
    }

    IEnumerator ShowText()
    {
        // Shows the text with the variable delay as the "speed" the text shows up
        for (int j = 0; j < fullTexts.Length; j++) 
        {
            currentFullText = fullTexts[j];
            for (int i = 0; i <= currentFullText.Length; i++)
            {
                currentText = currentFullText.Substring(0, i);
                dialogueText.text = currentText;
                yield return new WaitForSeconds(delay);
            }
            yield return new WaitForSeconds(1.3f);
            currentText = "";
            dialogueText.text = currentText;
        }
        dialogueInUse = false;
    }
}
