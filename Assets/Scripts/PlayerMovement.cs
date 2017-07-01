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
    //magnitude to move 
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
        if (Input.GetMouseButton(0))
        {
            print("Cursor raycast hit: " + cameraRaycaster.layerHit);
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
        var playerToClickPoint = currentClickTarget -transform.position ;
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

