using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_Account : MonoBehaviour
{

    private static Singleton_Account _instance;
    public static Singleton_Account instance
    {
        //Funcion get 
        get
        {
            if (_instance == null) //si  no hay nadaa pues XD lo creamos
            {
                GameObject _PlayerDataManager = new GameObject("Acc_Data");
                _PlayerDataManager.AddComponent<Singleton_Account>(); //Le a;adimos  este scrip al objeto
                
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

    //variable para indicar que nuestro usuario esta Online
    public bool IsOnline { get; set; }
    //Variable para indicar que nuestro usuario esta AFK
    public bool IsAFK { get; set; }
    #region Datos importantes de la cuenta
    public int AC_ID { get; set; }
    public string AC_Name { get; set; }
    public string AC_Server { get; set; }
    #endregion

    #region Guardar los datos del campeon seleccionado

    public int Char_ID { get; set; } //ID del Character Seleccionado
    

    #endregion




}


