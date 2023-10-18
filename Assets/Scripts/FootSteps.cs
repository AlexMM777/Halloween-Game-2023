using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public GameObject playerController, playerBody;
    public AudioSource audioSource;

    [Header("- - Audio Clips - -")]
    public AudioClip[] grassSteps;
    public AudioClip[] dirtSteps;
    public AudioClip[] tileSteps;
    public AudioClip[] woodSteps;
    public AudioClip[] stoneSteps;
    public AudioClip[] gravelSteps;
    public AudioClip[] leavesSteps;

    [Header("- - Texture Index (from terrain) - -")]
    public int grassIndex;
    public int dirtIndex;
    public int tileIndex;
    public int woodIndex;
    public int stoneIndex;
    public int gravelIndex;
    public int leavesIndex;
    
    

    [Header("- - Outputs - -")]
    public AudioClip[] chosenSounds;
    public AudioClip finalChosen;
    public bool isOnGround;
    public bool isOnObj;

    void Start()
    {
        finalChosen = stoneSteps[Random.Range(0, stoneSteps.Length)];
    }

    void Update()
    {
        isOnGround = playerController.GetComponent<PlayerMovement>().grounded;

        if(!isOnObj) {
            if (isOnGround)
            {
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == grassIndex)
                {
                    chosenSounds = grassSteps;
                    ChooseRandom();
                }
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == dirtIndex)
                {
                    chosenSounds = dirtSteps;
                    ChooseRandom();
                }
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == tileIndex)
                {
                    chosenSounds = tileSteps;
                    ChooseRandom();
                }
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == woodIndex)
                {
                    chosenSounds = woodSteps;
                    ChooseRandom();
                }
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == stoneIndex)
                {
                    chosenSounds = stoneSteps;
                    ChooseRandom();
                }
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == leavesIndex)
                {
                    chosenSounds = leavesSteps;
                    ChooseRandom();
                }
            }
        }
    }
    

    public void ChooseRandom()
    {
        finalChosen = chosenSounds[Random.Range(0, chosenSounds.Length)];
    }

    private void Step()
    {
        if (isOnGround)
        {
            audioSource.PlayOneShot(finalChosen);
        }
    }

}
