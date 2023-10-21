using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfPaused : MonoBehaviour
{
    public PlayerMovement playerMovementScript;
    public PlayerCam playerCam;
    public PlayerAnScript playerAnScript;
    public GameObject pauseScreen;

    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                pauseScreen.SetActive(false);
                playerMovementScript.enabled = true;
                playerCam.enabled = true;
                playerAnScript.canMove = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                isPaused = false;
            }
            else
            {
                pauseScreen.SetActive(true);
                playerMovementScript.enabled = false;
                playerCam.enabled = false;
                playerAnScript.canMove = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                isPaused = true;
            }
        }
    }
}
