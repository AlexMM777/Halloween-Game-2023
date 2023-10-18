using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnScript : MonoBehaviour
{
    public Animator m_Animator;
    public GameObject playerController;
    public bool canMove = false;

    void Start()
    {
        m_Animator.SetBool("isOnFloor", true);
    }

    void Update()
    {
      
            if (!playerController.GetComponent<PlayerMovement>().isSprinting)
            {
                m_Animator.SetBool("isRunning", false);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                m_Animator.SetBool("isCrouching", true);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                m_Animator.SetBool("isGoingForward", true);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                m_Animator.SetBool("isGoingLeft", true);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                m_Animator.SetBool("isGoingBack", true);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                m_Animator.SetBool("isGoingRight", true);
            }

            if (m_Animator.GetBool("isGoingForward") == true || m_Animator.GetBool("isGoingBack") == true)
            {
                if (playerController.GetComponent<PlayerMovement>().isSprinting)
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        m_Animator.SetBool("isRunning", true);
                    }
                }
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                if (playerController.GetComponent<PlayerMovement>().isSprinting)
                {
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                    {
                        m_Animator.SetBool("isRunning", true);
                    }
                }
            }
        

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            m_Animator.SetBool("isCrouching", false);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            m_Animator.SetBool("isGoingForward", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            m_Animator.SetBool("isGoingLeft", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            m_Animator.SetBool("isGoingBack", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            m_Animator.SetBool("isGoingRight", false);
        }


        m_Animator.SetBool("isAgainstWall", !canMove);
        m_Animator.SetBool("isOnFloor", playerController.GetComponent<PlayerMovement>().grounded);

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            m_Animator.SetBool("isRunning", false);
        }
        if (!playerController.GetComponent<PlayerMovement>().isSprinting)
        {
            m_Animator.SetBool("isRunning", false);
        }
    }
}







