using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLoc : MonoBehaviour
{
    public bool isInUse;
    public AdultNPCAI houseOwner;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isInUse)
        {
            if (other.gameObject.tag == "ChildNPC")
            {
                other.gameObject.GetComponent<ChildNPCAI>().isAtLoc = true;
                other.gameObject.GetComponent<ChildNPCAI>().adultScript = houseOwner;
                houseOwner.nearNPC = other.gameObject;
                isInUse = true;
            }
        }
        else if (other.gameObject.tag == "ChildNPC")
        {
            other.gameObject.GetComponent<ChildNPCAI>().selectedLoc = Random.Range(0, other.gameObject.GetComponent<ChildNPCAI>().houseLocs.Length);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ChildNPC")
        {
            if ((isInUse) & (other.gameObject.GetComponent<ChildNPCAI>().isAtLoc == true))
            {
                //Debug.Log("EXIT");
                other.gameObject.GetComponent<ChildNPCAI>().isAtLoc = false;
                isInUse = false;
            }
        }
    }
}
