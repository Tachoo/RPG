using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    #region CameraReycast
    CameraRaycaster cameraRayCaster;
    #endregion

    // Use this for initialization
    void Start ()
    {
        cameraRayCaster = GetComponent<CameraRaycaster>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(cameraRayCaster.layerHit);
	}
}
