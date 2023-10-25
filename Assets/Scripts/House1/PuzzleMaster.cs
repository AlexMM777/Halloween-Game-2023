using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PuzzleMaster : MonoBehaviour
{
    bool isCandle1Blown;
    bool isCandle2Blown;
    bool isHandOut;

    GameObject hand;
    bool summonHand = false;


    public float moveSpeed = 10f;
    private float startTime;
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
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
            if (journeyFraction >= 0.035f)
            {
                summonHand = false;
                isHandOut = true;
            }
        }
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
        // Slide hand upwards towards window
        summonHand = true;
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
                print("Talking to parrot");
            }
            if (isHandOut && other.tag == "Hand")
            {
                print("Hand Selected!");
            }
        }
    }
}
