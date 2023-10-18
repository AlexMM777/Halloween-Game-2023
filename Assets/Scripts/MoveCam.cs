using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform camPos;

    void Start()
    {
        
    }

    private void Update()
    {
        transform.position = camPos.position;
    }
}
