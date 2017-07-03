using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Estadisticas del jugador

         #region Vida y RecursoPrimario
    public int PuntosDeVida = 0;
    public int RecursoPrimario = 0;
    #endregion
         #region Estadisticas primarias

    public int Fuerza = 0;
    public int Destreza = 0;
    public int Inteligencia = 0;
    public int Fe = 0;
    #endregion
    #region Estadisticas Secundarias

    #region Resistencias primarias;

    public int Resistencia_Fisica = 0;
    public int Resistencia_Magica = 0;
    #endregion
    #region Resistencias Elementales
    public int Resistencia_Fuego = 0;
    public int Resistencia_Agua = 0;
    public int Resistencia_Hielo = 0;
    public int Resistencia_Tierra = 0;
    public int Resistencia_Viento = 0;
    public int Resistencia_Relampago = 0;
    #endregion

    #endregion

    #endregion
    BaseClass classebase= new BaseClass();
    // Use this for initialization
    void Start ()
    {

        classebase.Fuerza = 6;
        Fuerza = (classebase.Fuerza);
        Debug.Log("stats de fuerza " + Fuerza);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
