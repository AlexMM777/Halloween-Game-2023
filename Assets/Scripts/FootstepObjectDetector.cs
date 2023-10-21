using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepObjectDetector : MonoBehaviour
{
    public GameObject playerMesh;
    public bool currentlyOnObj;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (playerMesh.GetComponent<FootSteps>().isOnGround)
        {
            if (other.gameObject.tag == "Stone")
            {
                playerMesh.GetComponent<FootSteps>().isOnObj = true;
                playerMesh.GetComponent<FootSteps>().chosenSounds = playerMesh.GetComponent<FootSteps>().stoneSteps;
                playerMesh.GetComponent<FootSteps>().ChooseRandom();
                currentlyOnObj = true;
            }

            if (other.gameObject.tag == "Wood")
            {
                playerMesh.GetComponent<FootSteps>().isOnObj = true;
                playerMesh.GetComponent<FootSteps>().chosenSounds = playerMesh.GetComponent<FootSteps>().woodSteps;
                playerMesh.GetComponent<FootSteps>().ChooseRandom();
                currentlyOnObj = true;
            }
            if (other.gameObject.tag == "Tile")
            {
                playerMesh.GetComponent<FootSteps>().isOnObj = true;
                playerMesh.GetComponent<FootSteps>().chosenSounds = playerMesh.GetComponent<FootSteps>().tileSteps;
                playerMesh.GetComponent<FootSteps>().ChooseRandom();
                currentlyOnObj = true;
            }
            if (other.gameObject.tag == "Gravel")
            {
                playerMesh.GetComponent<FootSteps>().isOnObj = true;
                playerMesh.GetComponent<FootSteps>().chosenSounds = playerMesh.GetComponent<FootSteps>().gravelSteps;
                playerMesh.GetComponent<FootSteps>().ChooseRandom();
                currentlyOnObj = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "Stone")||(other.gameObject.tag == "Wood") || (other.gameObject.tag == "Tile") || (other.gameObject.tag == "Gravel"))
        {
            currentlyOnObj = false;
            StartCoroutine(CheckIfOnObjStill());
        }
    }

    IEnumerator CheckIfOnObjStill()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        if (!currentlyOnObj)
        {
            playerMesh.GetComponent<FootSteps>().isOnObj = false;
        }
    }
}
