using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChildNPCAI : MonoBehaviour
{
    public bool arrivedAtHouse = false;
    public TextDialogue3D dialogueScript;
    public AdultNPCAI adultScript;

    public Transform[] locations;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoTo();
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

    public void GoTo()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = locations[0].position;
    }
}
