using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AdultNPCAI : MonoBehaviour
{
    public bool childKnocked = false;
    public DoorScript door;
    public Transform targetDoor;
    public Transform targetInside;
    public TextDialogue3D dialogueScript;
    public GameObject body;

    private float speed = 1;
    private bool openedDoor = false;
    private bool goToDoor = false;
    private bool gaveCandy = false;
    private bool goInside = false;
    private bool wentOutside = false;
    private Animator m_Animator;
    public GameObject nearNPC;

    void Start()
    {
        m_Animator = body.GetComponent<Animator>();
    }

    void Update()
    {
        if (childKnocked)
        {
            if(!wentOutside)
            {
                door.openDoor = true;
                if (!openedDoor)
                {
                    m_Animator.SetTrigger("openDoor");
                    StartCoroutine(WalkAfterDelay());
                    openedDoor = true;
                }
                if (goToDoor)
                {
                    GoToTarget(targetDoor);
                }
                if (Vector3.Distance(targetDoor.position, body.transform.position) < 0.3)
                {
                    m_Animator.SetBool("isWalking", false);
                    if (!gaveCandy)
                    {
                        StartCoroutine(GiveCandy());
                        gaveCandy = true;
                    }
                }
            }
            
            if (goInside)
            {
                GoToTarget(targetInside);
                body.transform.LookAt(targetInside);
                m_Animator.SetBool("isWalking", true);

                if (Vector3.Distance(targetInside.position, body.transform.position) < 0.3)
                {
                    m_Animator.SetBool("isWalking", false);
                    goInside = false;
                    body.transform.LookAt(targetDoor);
                    m_Animator.SetTrigger("closeDoor");
                    door.openDoor = false;
                    ResetCharacter();
                }
            }
        }


    }

    public void GoToTarget(Transform target)
    {
        float step = speed * Time.deltaTime;
        body.transform.position = Vector3.MoveTowards(body.transform.position, target.position, step);
    }

    private IEnumerator WalkAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        m_Animator.SetBool("isWalking", true);
        goToDoor = true;
    }

    private IEnumerator GiveCandy()
    {
        dialogueScript.SaySomething("Enjoy!!");
        m_Animator.SetTrigger("giveCandy");
        nearNPC.GetComponent<ChildNPCAI>().animator.SetTrigger("getCandy");
        yield return new WaitForSeconds(4f);
        wentOutside = true;
        goInside = true;
    }

    private void ResetCharacter()
    {
        //Debug.Log("RESET CHARACTERS");
        childKnocked = false;
        openedDoor = false;
        goToDoor = false;
        gaveCandy = false;
        goInside = false;
        wentOutside = false;
        nearNPC.GetComponent<ChildNPCAI>().leftHouse = true;
        nearNPC.GetComponent<ChildNPCAI>().arrivedAtHouse = false;
    }
}
