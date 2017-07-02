using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    #region Variables&References
    ThirdPersonCharacter m_Character;   
    CameraRaycaster cameraRaycaster;
    Vector3 CurrentDestination;
    Vector3 Clickpoint;
    #region Serialized 
    [SerializeField] bool IsInDirecMode = false; //TO DO consider making a static later
    [SerializeField] float walkStopRadius = 0.2f;
    [SerializeField] float AttackStopRadius = 5f;
    #endregion
    #endregion

    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        CurrentDestination = transform.position;
    }
    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            IsInDirecMode = !IsInDirecMode;
            CurrentDestination = transform.position;
        }
        if (IsInDirecMode)
        {
            //Gamepad
            ProcessInDirecMovement();
        }
        else
        {
           // ProcessInDirecMovementClick();//Mouse movement
        }
    }
    #region GamePad Key&Mouse
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
    //private void ProcessInDirecMovementClick()
    //{
    //    if (Input.GetMouseButton(1))
    //    {
    //        Clickpoint = cameraRaycaster.hit.point;
    //        switch (cameraRaycaster.layerHit)
    //        {
    //            case Layer.Walkable:
    //                CurrentDestination = ShortDestination(Clickpoint, walkStopRadius);
    //                break;

    //            case Layer.Enemy:
    //                CurrentDestination = ShortDestination(Clickpoint, AttackStopRadius);
    //                break;

    //            default:
    //                print("Shouldn't Be here");
    //                break;
    //        }

    //    }
    //    WalktoDestination();
    //}

    private void WalktoDestination()
    {
        var playerToClickPoint = CurrentDestination - transform.position;
        if (playerToClickPoint.magnitude >= 0)
        {
            m_Character.Move(CurrentDestination - transform.position, false, false);
        }
        else
        {
            m_Character.Move(Vector3.zero, false, false);
        }
    }
    #endregion
    #region shortest
    Vector3 ShortDestination(Vector3 destination,float shorteing)
    {
        Vector3 reductionVector = (destination - transform.position).normalized * shorteing;
        return destination - reductionVector;
    }
    #endregion
    #region Gizmos
    private void OnDrawGizmos()
    {
        #region DistanceToClick_Gizmo
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, CurrentDestination);
        Gizmos.DrawSphere(CurrentDestination, 0.1f);
        Gizmos.DrawSphere(Clickpoint, 0.4f);
        //Draw Attack Radius 
        Gizmos.color = new Color(255f, 0f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, AttackStopRadius);
        #endregion
    }
    #endregion
}

