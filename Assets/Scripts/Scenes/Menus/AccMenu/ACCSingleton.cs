using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACCSingleton : MonoBehaviour
{
    
    private static ACCSingleton _instance;
    public static ACCSingleton instance
    {
        //Funcion get 
        get
        {
            if (_instance == null) //si  no hay nadaa pues XD lo creamos
            {
                GameObject _PlayerDataManager = new GameObject("_PlayerDataManager");
                _PlayerDataManager.AddComponent<ACCSingleton>(); //Le a;adimos  este scrip al objeto
                //Hacking
                
                //
            }
            return _instance; //Retornamos el objeto que esta como privado
        }

    }
    void Awake()
    {
      
        DontDestroyOnLoad(this.gameObject);
        _instance = this;

    }

    /*Cuales datos me interesa saber del juegador*/

    public bool IsAlive { get; set; }
    public bool IsAFK { get; set; }
    //public Haking Hack_Skill= _instance.GetComponent<Haking>();



}