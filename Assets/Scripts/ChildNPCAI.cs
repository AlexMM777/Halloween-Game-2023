using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChildNPCAI : MonoBehaviour
{
    public bool arrivedAtHouse = false;
    public bool leftHouse;
    public TextDialogue3D dialogueScript;
    public Animator animator;
    public AdultNPCAI adultScript;   
    public HouseLoc[] houseLocs;
    public bool isAtLoc;

    private NavMeshAgent agent;
    public int selectedLoc = 0;
    private int previousLoc = -1;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // 4 TESTING
        //selectedLoc = 1;
        isAtLoc = false;
        selectedLoc = 1;
        //selectedLoc = Random.Range(0, houseLocs.Length);
        //animator.SetBool("isWalking", true);
        //
    }

    void Update()
    {     
        if (leftHouse)
        {
            previousLoc = selectedLoc;
            //isAtLoc = false;
            selectedLoc = Random.Range(0, houseLocs.Length);
            //Debug.Log("GET OFF ME LAWN");
            leftHouse = false;
        }
        if (!arrivedAtHouse)
        {
            StartCoroutine(GoTo());
        }
    }

    private IEnumerator Knock()
    {
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
        if (houseLocs[selectedLoc].isInUse == false)
        {
            animator.SetBool("isWalking", true);
            if (selectedLoc != previousLoc)
            {
                agent.destination = houseLocs[selectedLoc].transform.position;
            }
        }
        else if (houseLocs[selectedLoc].isInUse == true & !isAtLoc)
        {
            selectedLoc = Random.Range(0, houseLocs.Length);
        }
        if ((Vector3.Distance(houseLocs[selectedLoc].transform.position, transform.position) < 0.3) & (isAtLoc == true))
        {
            arrivedAtHouse = true;
            StartCoroutine(Knock());
            yield return new WaitForSeconds(2f);
            adultScript.childKnocked = true;
        }
    }
}
