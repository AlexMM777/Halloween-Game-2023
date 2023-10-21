using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ChangeMouseSens : MonoBehaviour
{
    public PlayerCam playerCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMouseSensitivity(float value)
    {
        // Default is 10
        playerCam.mouseSensitivity = value;
    }
}
