using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeObserver : MonoBehaviour {
     #region CameraRayCaster
    CameraRaycaster CameraRayCasT;
     #endregion
    void Start ()
    {
        CameraRayCasT = GetComponent<CameraRaycaster>(); 
        CameraRayCasT.OnlayerChange += Some;       
    }
	
	void Update ()
    {
		
	}
    void Some(Layer newlayer)
    {
        //print("yahoo handled form elewhere");
    }
}
