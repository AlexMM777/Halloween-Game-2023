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

    private float speed = 1;
    private Animator m_Animator;
    private bool openedDoor = false;
    private bool goToDoor = false;
    private bool gaveCandy = false;
    private bool goInside = false;
    private bool wentOutside = false;
    
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
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
                if (Vector3.Distance(targetDoor.position, transform.position) == 0)
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
                transform.LookAt(targetInside);
                m_Animator.SetBool("isWalking", true);

                if (Vector3.Distance(targetInside.position, transform.position) == 0)
                {
                    m_Animator.SetBool("isWalking", false);
                    goInside = false;
                    transform.LookAt(targetDoor);
                    m_Animator.SetTrigger("closeDoor");
                    door.openDoor = false;
                    ResetCharacter();
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ChildNPC"))
        {
            other.gameObject.GetComponent<ChildNPCAI>().adultScript = this.GetComponent<AdultNPCAI>();
            if(childKnocked)
            {
                //
            }
        }
    }

    public void GoToTarget(Transform target)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    private IEnumerator WalkAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        m_Animator.SetBool("isWalking", true);
        goToDoor = true;
    }

    public void Step()
    {
        //filler
    }

    private IEnumerator GiveCandy()
    {
        dialogueScript.SaySomething("Enjoy!!");
        m_Animator.SetTrigger("giveCandy");
        yield return new WaitForSeconds(4f);
        wentOutside = true;
        goInside = true;
    }

    private void ResetCharacter()
    {
        childKnocked = false;
        openedDoor = false;
        goToDoor = false;
        gaveCandy = false;
        goInside = false;
        wentOutside = false;
    }
}

