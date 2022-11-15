using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Go through each line of this script and explain what it does as we go through it
* Edit some of the variables and see what happens
*/

//What's this class for?
public class FPS_Camera : MonoBehaviour
{
    public float maximumX = 60f; //field of view
    public float minimumX = -60f; //Field of view
    public float turnSpeed = 5f; //Sets turn speed
    public Camera cam; //Uses camera for vision
    float rotX = 0f;
    float rotY = 0f; 

    void Update()
    {
        PlayerLook();
        Cursor.lockState = CursorLockMode.Locked; //locks the camera to first person/hides the cursour
    }

    void PlayerLook()
    {
        rotX += Input.GetAxis("Mouse Y") * turnSpeed; //constant calculation/rotating around Y angle
        rotY += Input.GetAxis("Mouse X") * turnSpeed; //constant calculation/rotating around the X angle

        rotX = Mathf.Clamp(rotX, minimumX, maximumX); //Calculations

        transform.localEulerAngles = new Vector3(0, rotY, 0); //rotates/ euler angles hands all shapes
        cam.transform.localEulerAngles = new Vector3(-rotX, 0, 0); //using camera's transform
    }
}
