using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObjZoom : MonoBehaviour
{
    float minFov = 10f;
    float maxFov = 60f;
    float sensitivity = 10f;
    public Transform target;


    void Update()
    {
        transform.LookAt(target);
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
