using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController_Motor : MonoBehaviour
{

    public PlayerStats stats;
    CharacterController character;
    public GameObject cam;
    float moveFB, moveLR;
    float rotX, rotY;
    float sensitivity;
    public bool webGLRightClickRotation = true;



    void Start()
    {
        //LockCursor ();
        character = GetComponent<CharacterController>();
        sensitivity = stats.sensitivity;
        if (Application.isEditor)
        {
            webGLRightClickRotation = false;
            sensitivity = sensitivity * 2;
        }
    }



    void Update()
    {
        moveFB = Input.GetAxis("Horizontal") * stats.speed;
        moveLR = Input.GetAxis("Vertical") * stats.speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        Vector3 movement = new Vector3(moveFB, -9.8f, moveLR);



        if (webGLRightClickRotation)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                CameraRotation(cam, rotX, rotY);
            }
        }
        else if (!webGLRightClickRotation)
        {
            CameraRotation(cam, rotX, rotY);
        }

        movement = transform.rotation * movement;
        character.Move(movement * Time.deltaTime);
    }


    void CameraRotation(GameObject cam, float rotX, float rotY)
    {
        transform.Rotate(0, rotX * Time.deltaTime, 0);
        cam.transform.Rotate(-rotY * Time.deltaTime, 0, 0);
    }




}
