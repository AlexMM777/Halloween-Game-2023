using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfHittingWall : MonoBehaviour
{
    public GameObject playerMesh;

    void Start()
    {
        playerMesh.GetComponent<PlayerAnScript>().canMove = true;
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Hide"))
        {
            playerMesh.GetComponent<PlayerAnScript>().canMove = false;
        }
        else if (other.gameObject.GetComponent<CustomTag>() != null)
        {
            if (other.gameObject.GetComponent<CustomTag>().HasTag("Hide"))
            {
                playerMesh.GetComponent<PlayerAnScript>().canMove = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hide"))
        {
            //Debug.Log("true");
            playerMesh.GetComponent<PlayerAnScript>().canMove = true;
        }
        else if (other.gameObject.GetComponent<CustomTag>() != null)
        {
            if (other.gameObject.GetComponent<CustomTag>().HasTag("Hide"))
            {
                playerMesh.GetComponent<PlayerAnScript>().canMove = true;
            }
        }
    }

}
