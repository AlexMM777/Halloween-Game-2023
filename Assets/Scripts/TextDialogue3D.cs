using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class TextDialogue3D : MonoBehaviour
{
    // Place script on 3D text

    public GameObject playerCam;
    public GameObject dialogueHolder;
    public bool dialogueInUse;
    
    private TMP_Text dialogueText;
    private float delay = 0.05f;
    private string fullText;
    private string currentText = "";
    
    public void Start()
    {
        dialogueText = this.GetComponent<TMP_Text>();
    }
    public void Update()
    {
        // Skip dialogue by clearing text
        if (Input.GetKeyDown("space"))
        {
            fullText = "";
            currentText = "";
            dialogueText.text = currentText;
            dialogueInUse = false;
        }
        dialogueHolder.transform.LookAt(playerCam.transform);
    }

    public void SaySomething(string dialogue)
    {
        // Input what you want character to say
        if (!dialogueInUse)
        {
            fullText = dialogue;
            dialogueInUse = true;
            StartCoroutine(ShowText());
        }
    }

    IEnumerator ShowText()
    {
        // Shows the text with the variable delay as the "speed" the text shows up
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            dialogueText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(1.3f);
        currentText = "";
        dialogueText.text = currentText;
        dialogueInUse = false;
    }
}
