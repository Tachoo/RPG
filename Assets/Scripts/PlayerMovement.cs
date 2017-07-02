using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    ThirdPersonCharacter m_Character;   
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;

    [SerializeField] bool IsInDirecMode = false; //TO DO consider making a static later
    [SerializeField] float walkStopRadius = 0.2f;

    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            IsInDirecMode = !IsInDirecMode;
            currentClickTarget = transform.position;
        }
        if (IsInDirecMode)
        {
            //Gamepad
            ProcessInDirecMovement();
        }
        else
        {
            ProcessInDirecMovementClick();//Mouse movement
        }
    }
    private void ProcessInDirecMovement()
    {
        //
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        //calculate camera relative dir
       Vector3 m_camforward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
       Vector3 m_move = v * m_camforward + h * Camera.main.transform.right;

        //
        m_Character.Move(m_move, false, false);



    }
    private void ProcessInDirecMovementClick()
    {
        if (Input.GetMouseButton(1))
        {
           
            switch (cameraRaycaster.layerHit)
            {
                case Layer.Walkable:
                    currentClickTarget = cameraRaycaster.hit.point;
                    break;

                case Layer.Enemy:
                    print("Not Moving to enemy");
                    break;

                default:
                    print("Shouldn't Be here");
                    break;
            }

        }
        var playerToClickPoint = currentClickTarget - transform.position;
        if (playerToClickPoint.magnitude >= walkStopRadius)
        {
            m_Character.Move(currentClickTarget - transform.position, false, false);
        }
        else
        {
            m_Character.Move(Vector3.zero, false, false);
        }
    }
}

