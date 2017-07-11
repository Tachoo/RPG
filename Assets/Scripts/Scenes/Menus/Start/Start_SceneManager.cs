using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Elemental para la gestion se scenas
using UnityEngine.UI;//Elemental para gestion de el Engine
//Objetivo de este script: 
/* 1
 * Hacer un crosfdade rapido
 * 2
 * hacer un blur cuando inicia el script  a quitarle el blur
 * hacer un blur hacia cuando termina la scena
 */
public class Start_SceneManager : MonoBehaviour
{
    #region Reference to Multi-Obj
    public GameObject Menu_Panel;
    public GameObject Text;
    #endregion
    private void Awake()
    {
        //Llamamos la funcion local
        _Corssfade(Menu_Panel, Text, 0, 1.5f);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void LateUpdate()
    {
        if (Input.anyKeyDown || Input.GetButtonDown("Submit"))
        {
            _Corssfade(Menu_Panel, Text, 1, 1.5f);
            LogInAccount();
        }
    }

    #region Funcion CorssFade
    // Hacemos el ultimo valor como default en False
    public void _Corssfade(GameObject _Panel, GameObject _text, float _alpha, float _duration, bool _timescale = false)
    {
        _Panel.GetComponent<Image>().CrossFadeAlpha(_alpha, _duration, _timescale); // Inicio de scena
        _text.SetActive(false);
    }// Hacemos el cossfade de paneles junto con texto
    #endregion

    #region Funciones desde el menu

    public void LogInAccount()/*Mandarlo A la scenea de NewGame*/
    {
        Debug.Log("LogIn");

         SceneManager.LoadScene(1);// Creacion de nueva partida
    }
   
   

    #endregion
}