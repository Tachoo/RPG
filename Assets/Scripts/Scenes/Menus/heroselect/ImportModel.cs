using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportModel : MonoBehaviour {

    public Quaternion rotation = Quaternion.Euler(270, 180, 180);
    // Use this for initialization
    void Start ()
    {
        CaballeroModel();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CaballeroModel()
    {
        // Instantiates a prefab named "enemy" located in any Resources
        // folder in your project's Assets folder.
        GameObject instance = Instantiate(Resources.Load("Naruto", typeof(GameObject)),transform.position, Quaternion.identity, transform)as GameObject;
        instance.transform.Rotate(270.0f,0.0f,180.0f);
        instance.transform.localScale = new Vector3(0.5f,0.5f,0.5f);

    }
}
