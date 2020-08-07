using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public Vector3 moveDirection;
    public float vertical;
    public float horizontal;
    public float speed = 10;
    public Transform CameraTransform;
    public DynamicJoystick dynamicJoystick;
    private CharacterController characterController;
    private bool accel = true;
    void Start()
    {
        CameraTransform = Camera.main.transform;
        characterController = GetComponent<CharacterController>();
    }


    void FixedUpdate()
    {
        moving();
    }

    public void moving(){
        float x = 0;
        float z = 0;
        if(accel){
            x = -Input.acceleration.y;
            z = Input.acceleration.x;
        }
        vertical = Input.GetAxis("Vertical")+dynamicJoystick.Vertical-x;
        horizontal = Input.GetAxis("Horizontal")+dynamicJoystick.Horizontal+z;
        Vector3 moveDir = CameraTransform.up * vertical;
        moveDir += CameraTransform.right * horizontal;
        moveDir.Normalize();
        moveDirection = moveDir;
        characterController.Move(moveDirection * Time.deltaTime*speed);
    }

    public void useAccelerometr(){
        accel =! accel;
    }
}
