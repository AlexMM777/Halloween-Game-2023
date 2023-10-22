using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildNPCAI : MonoBehaviour
{
    public bool arrivedAtHouse = false;
    public TextDialogue3D dialogueScript;
    public AdultNPCAI adultScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (arrivedAtHouse)
        {
            StartCoroutine(Knock());
            arrivedAtHouse = false;
        }
    }

    private IEnumerator Knock()
    {
        dialogueScript.SaySomething("Trick or treat!!");
        yield return new WaitForSeconds(2f);
        if (dialogueScript.dialogueInUse == false)
        {
            adultScript.childKnocked = true;
        }
    }
}
