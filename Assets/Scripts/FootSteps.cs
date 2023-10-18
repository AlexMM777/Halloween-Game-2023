using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public GameObject playerController, playerBody;
    public AudioSource audioSource;

    [Header("- - Audio Clips - -")]
    public AudioClip[] grassSteps;
    public AudioClip[] stoneSteps;
    public AudioClip[] dirtSteps;
    public AudioClip[] woodSteps;
    public AudioClip[] carpetSteps;
    public AudioClip[] leavesSteps;

    [Header("- - Texture Index (from terrain) - -")]
    public int grassIndex;
    public int stoneIndex;
    public int dirtIndex;
    public int leavesIndex;
    public int woodIndex;
    public int carpetIndex;

    [Header("- - Outputs - -")]
    public AudioClip[] chosenSounds;
    public AudioClip finalChosen;
    public bool isOnGround;
    public bool isOnObj;

    // Start is called before the first frame update
    void Start()
    {
        finalChosen = stoneSteps[Random.Range(0, stoneSteps.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = playerController.GetComponent<PlayerMovement>().grounded;

        if(!isOnObj) {
            //Debug.Log("Is on terrain");
            if (isOnGround)
            {
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == stoneIndex)
                {
                    //Debug.Log("Stone");
                    chosenSounds = stoneSteps;
                    ChooseRandom();
                }
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == grassIndex)
                {
                    //Debug.Log("Grass");
                    chosenSounds = grassSteps;
                    ChooseRandom();
                }
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == dirtIndex)
                {
                    //Debug.Log("Dirt");
                    chosenSounds = dirtSteps;
                    ChooseRandom();
                }
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == leavesIndex)
                {
                    //Debug.Log("WoodChip");
                    chosenSounds = leavesSteps;
                    ChooseRandom();
                }
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == woodIndex)
                {
                    //Debug.Log("Wood");
                    chosenSounds = woodSteps;
                    ChooseRandom();
                }
                if (playerBody.GetComponent<TerrainTextureDetector>().surfaceIndex == carpetIndex)
                {
                    //Debug.Log("Carpet");
                    chosenSounds = carpetSteps;
                    ChooseRandom();
                }
            }
        }
    }
    

    public void ChooseRandom()
    {
        //audioSource.clip = chosenSounds[Random.Range(0, chosenSounds.Length)];
        finalChosen = chosenSounds[Random.Range(0, chosenSounds.Length)];
        //audioSource.Play();
    }

    private void Step()
    {
        if (isOnGround)
        {
            audioSource.PlayOneShot(finalChosen);
        }
    }

}
