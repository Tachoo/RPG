using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement; // Elemental para la gestion se scenas
using UnityEngine.Networking;
using UnityEngine.UI;//Elemental para gestion de el Engine

public class DisplayMultipleInstanceMessajes : MonoBehaviour {
    Vector3 Trolllol;
    public GameObject prefab_menssaje;
	// Use this for initialization
	void Start ()
    {
        Trolllol = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < 8; i++)
            {
                Instantiate(prefab_menssaje, Trolllol += new Vector3(0,200, 0), Quaternion.identity, prefab_menssaje.transform);
            }
            
        }
        
	}

}
