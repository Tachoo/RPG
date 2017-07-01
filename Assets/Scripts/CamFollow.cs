using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {
    #region Private GameObj Player;
    private GameObject Player;
    #endregion
    // Use this for initialization
    void Start ()
    {
        //Encontramos el objeto al que queremos seguir por medio de tags 
        Player= GameObject.FindGameObjectWithTag("Player");
        //Solo para debugear logeamos el nombre
        Debug.Log(Player.name);
	}
    //Usamos el lateUpdate  para que solo se actualize 1 vez por frame	
    void LateUpdate()
    {
        transform.position = Player.transform.position;    
    }
}
