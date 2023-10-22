using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool openDoor;
    private float rotationSpeed;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (openDoor && !isOpen)
        {
            StartCoroutine(RotateMe(Vector3.up * 80, 1.7f));
            isOpen = true;
        }
        if (!openDoor && isOpen)
        {
            StartCoroutine(RotateMe(Vector3.down * 80, 1.7f));
            isOpen = false;
        }
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        // Closed angle is 180
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }
    }
}
