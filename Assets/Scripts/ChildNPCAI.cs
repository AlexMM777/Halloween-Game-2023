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
    private NavMeshAgent agent;
    private int selectedLoc = 0;
    private int previousLoc = -1;
    public bool leftHouse = false;
    public Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // 4 TESTING
        selectedLoc = 1;
        leftHouse = false;
        animator.SetBool("isWalking", true);
        //
    }

    void Update()
    {     
        if (leftHouse)
        {
            selectedLoc = Random.Range(0, locations.Length);
            animator.SetBool("isWalking", true);
            Debug.Log("GET OFF ME LAWN");
            leftHouse = false;
        }
        if (!arrivedAtHouse)
        {
            StartCoroutine(GoTo());
        }
    }

    private IEnumerator Knock()
    {
        Debug.Log("STOP WALKING");
        animator.SetBool("isWalking", false);
        dialogueScript.SaySomething("Trick or treat!!");
        yield return new WaitForSeconds(2f);
        if (dialogueScript.dialogueInUse == false)
        {
            adultScript.childKnocked = true;
        }
    }

    public IEnumerator GoTo()
    {
        if (selectedLoc != previousLoc)
        {
            agent.destination = locations[selectedLoc].position;
        }
        previousLoc = selectedLoc;

        if (Vector3.Distance(locations[selectedLoc].position, transform.position) < 0.3)
        {
            arrivedAtHouse = true;
            StartCoroutine(Knock());
            yield return new WaitForSeconds(2f);
            adultScript.childKnocked = true;
            //Debug.Log("HOWDY");
        }
    }
}
