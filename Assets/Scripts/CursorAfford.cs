using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAfford : MonoBehaviour {
    #region Variables
    private CameraRaycaster cameraRayCaster;
    [SerializeField] Texture2D WalkCursor = null;
    [SerializeField] Texture2D EnemyCursor = null;
    [SerializeField] Texture2D StopCursor = null;

    [SerializeField] Vector2 cursorhospot = new Vector2(96, 96);
    #endregion
    // Use this for initialization
    void Start ()
    {
        cameraRayCaster = GetComponent<CameraRaycaster>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (cameraRayCaster.layerHit)
        {
            case Layer.Walkable:
                Cursor.SetCursor(WalkCursor, cursorhospot, CursorMode.Auto);
                break;
            case Layer.Enemy:
                Cursor.SetCursor(EnemyCursor, cursorhospot, CursorMode.Auto);
                break;
            case Layer.RaycastEndStop:
                Cursor.SetCursor(StopCursor, cursorhospot, CursorMode.Auto);
                break;
            default:
                Debug.Log("unknow Cursor to display");
                break;
        }
    }
}
