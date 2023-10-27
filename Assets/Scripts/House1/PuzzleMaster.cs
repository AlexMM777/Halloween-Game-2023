using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PuzzleMaster : MonoBehaviour
{
    bool isCandle1Blown;
    bool isCandle2Blown;
    float timeSinceHandOut = 0;
    bool handBackIn;
    bool handReadyToGiveKey;
    bool hasKnowckedTopDoor;
    bool witchReadyToAppear;

    HashSet<string> inventory = new HashSet<string>();

    GameObject hand;
    bool summonHand = false;


    float moveSpeed = 1f;
    private float startTime;
    private float journeyLength;

    public TextMeshProUGUI inventoryUI;
    // The object the player is currently looking at.
    private GameObject targetObject;
    private GameObject topWindow;

    // The angle at which the player is considered to have looked away.
    public float lookAwayAngle = 30f;

    // Start is called before the first frame update
    void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag("KeyParent");
        topWindow= GameObject.FindGameObjectWithTag("TopWindow");

        hand = GameObject.FindGameObjectWithTag("Hand");
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, hand.transform.GetChild(0).position);
    }

    // Update is called once per frame
    void Update()
    {
        if(summonHand)
        {   
            float distanceCovered = (Time.time - startTime) * moveSpeed * Time.deltaTime;
            float journeyFraction = distanceCovered / journeyLength;

            // Use Mathf.Lerp to interpolate the position between current and target positions
            hand.transform.GetChild(1).position = Vector3.Lerp(hand.transform.GetChild(1).position, hand.transform.GetChild(0).position, journeyFraction);
            // You can also check if the object has reached the target and perform any actions.
            if (timeSinceHandOut < 5)
            {
                timeSinceHandOut += Time.deltaTime;
            }  
        }
        if(handBackIn)
        {
            float distanceCovered = (Time.time - startTime) * (moveSpeed/2) * Time.deltaTime;
            float journeyFraction = distanceCovered / journeyLength;

            // Use Mathf.Lerp to interpolate the position between current and target positions
            hand.transform.GetChild(1).position = Vector3.Lerp(hand.transform.GetChild(1).position, hand.transform.GetChild(2).position, journeyFraction);
            // You can also check if the object has reached the target and perform any actions.
            if (journeyFraction >= 0.035f)
            {
                handBackIn = false;
                handReadyToGiveKey = true;
            }
        }
        if (handReadyToGiveKey)
        {
            if (!IsObjectVisible(targetObject))
            {
                GameObject.FindGameObjectWithTag("Keyz").transform.GetChild(0).gameObject.SetActive(true);
                handReadyToGiveKey = false;
            }
        }
        if (witchReadyToAppear)
        {
            if (!IsObjectVisible(topWindow))
            {
                // play witch sound effect
                GameObject.FindGameObjectWithTag("CandyCorn").transform.GetChild(0).gameObject.SetActive(true);
                witchReadyToAppear = false;
            }
        }
    }

    // Check if the target object is currently visible to the camera
    private bool IsObjectVisible(GameObject target)
    {
        if (target == null)
            return false;

        // Check if any part of the object's renderer is visible to the camera
        Renderer renderer = target.GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer.isVisible;
        }

        return false;
    }

    private void BlowCandle(Collider other)
    {
        // replace model with blown candle
        other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        other.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        // TODO blow sound effect
        if (isCandle1Blown && isCandle2Blown)
        {
            SummonHand();
        }
    }
    private void SummonHand()
    {
        // Activate rowdy noise for hand
        summonHand = true;
    }

    private void refreshInventoryUI()
    {
        String uiOutput = "";
        foreach (string items in inventory)
        {
            uiOutput += "-" + items;
        }
        inventoryUI.text = uiOutput;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (!(isCandle1Blown && isCandle2Blown))
            {
                if (other.tag == "Candle1")
                {
                    isCandle1Blown = true;
                    BlowCandle(other);
                }
                if (other.tag == "Candle2")
                {
                    isCandle2Blown = true;
                    BlowCandle(other);
                }
            }
            if (other.tag == "Bottom Floor Door")
            {
                print("Rattling first floor door!");
            }
            if (other.tag == "Parrot")
            {
                if (inventory.Contains("CandyCorn"))
                {
                    print("Gave candy to parrot and unlocked door");
                    inventory.Remove("CandyCorn");
                    // update inventory UI
                    refreshInventoryUI();

                    // remove lock from door
                    GameObject.FindGameObjectWithTag("Bottom Floor Door").SetActive(false);
                } else
                {
                    print("Talking to parrot");
                }
            }
            if (other.tag == "CandyCane" && !inventory.Contains("CandyCane"))
            {
                other.gameObject.SetActive(false);
                inventory.Add("CandyCane");
                // update inventory UI
                refreshInventoryUI();
            }
            if (other.tag == "CandyCornz" && !inventory.Contains("CandyCorn"))
            {
                other.gameObject.SetActive(false);
                inventory.Add("CandyCorn");
                // update inventory UI
                refreshInventoryUI();
            }
            if (other.tag == "Key" && !inventory.Contains("Key"))
            {
                other.gameObject.SetActive(false);
                inventory.Add("Key");
                // update inventory UI
                refreshInventoryUI();
            }
            if (other.tag == "Top Door" && !hasKnowckedTopDoor)
            {
                // Play knock sound effect
                hasKnowckedTopDoor = true;
                witchReadyToAppear = true;
            }
            if (other.tag == "Lock" && inventory.Contains("Key"))
            {
                inventory.Remove("Key");
                // update inventory UI
                refreshInventoryUI();
                print("YOU DID IT!");
            }
            if (summonHand && other.tag == "Hand")
            {
                if (inventory.Contains("CandyCane") && timeSinceHandOut >= 5)
                {
                    inventory.Remove("CandyCane");
                    refreshInventoryUI();
                    other.gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
                    summonHand = false;
                    handBackIn = true;
                }
            }
        }
    }
}
