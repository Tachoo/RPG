﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement; // Elemental para la gestion se scenas
using UnityEngine.Networking;
using UnityEngine.UI;//Elemental para gestion de el Engine

public class Chatsystem : MonoBehaviour {

    public GameObject chatzone;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #region DisplayChatRegion
    public void ShowHide()
    {
        chatzone.SetActive(!chatzone.active);

    }
    #endregion
}
