using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfHittingWall : MonoBehaviour
{
    public GameObject playerBody;

    void Start()
    {
        playerBody.GetComponent<PlayerAnScript>().canMove = true;
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Hide"))
        {
            playerBody.GetComponent<PlayerAnScript>().canMove = false;
        }
        else if (other.gameObject.GetComponent<CustomTag>() != null)
        {
            if (other.gameObject.GetComponent<CustomTag>().HasTag("Hide"))
            {
                playerBody.GetComponent<PlayerAnScript>().canMove = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hide"))
        {
            //Debug.Log("true");
            playerBody.GetComponent<PlayerAnScript>().canMove = true;
        }
        else if (other.gameObject.GetComponent<CustomTag>() != null)
        {
            if (other.gameObject.GetComponent<CustomTag>().HasTag("Hide"))
            {
                playerBody.GetComponent<PlayerAnScript>().canMove = true;
            }
        }
    }

}
