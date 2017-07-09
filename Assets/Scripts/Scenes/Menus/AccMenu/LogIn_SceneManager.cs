using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement; // Elemental para la gestion se scenas
using UnityEngine.Networking;
using UnityEngine.UI;//Elemental para gestion de el Engine

public class LogIn_SceneManager : MonoBehaviour
{

    //Datos devueltos por la base de datos
    public string[] items;
    #region UI Fields
    public InputField User_data;
    public InputField Pass_Data;
    #endregion
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    #region Formulario  de Inicio de session y boton de submit
    /**/
    #region Funcion Prinicipal de Inicio de session

    public void LogIn()
    {
        StartCoroutine(Login_SendDataDB(User_data.text, (string)Pass_Data.text));
    }
    #endregion
    /**/
    #region Enumerator para el envio de informacion
    public IEnumerator Login_SendDataDB(string user, string pass)
    {
        WWWForm form = new WWWForm();
        form.AddField("user", user);
        form.AddField("pass", pass);

        WWW itemsData = new WWW("http://www.tachoo.xyz/APIDB/UnitytoDB.php",form);

        yield return itemsData;
        string itemsDataString = itemsData.text;
        print(itemsDataString);
        
        items = itemsDataString.Split(';');

    }
    #endregion
    /**/
     #region Clean Strings
    /**/
    #region CleanBase
     public string CleanBase(string _string)
    {
        for (int i = 0; i < 6; i++) //Hacemos el for para que repita entre toda la cadena.. literalmente si no tiene nada de lo anterior  entrara directo al else 6 veces
        {

            if (_string.Contains(";"))
            {
                _string = _string.Remove(_string.IndexOf(";"));
            }
            else if (_string.Contains("'"))
            {
                _string = _string.Remove(_string.IndexOf("'"));
            }
            else if (_string.Contains("<"))
            {
                _string = _string.Remove(_string.IndexOf("<"));
            }
            else if (_string.Contains("/"))
            {
                _string = _string.Remove(_string.IndexOf("/"));
            }
            else if (_string.Contains(">"))
            {
                _string = _string.Remove(_string.IndexOf(">"));
            }
            else
            {

            }
        }
        //hasta que pase el filtro va a mandar la string ya saneada
        return _string;
    }
    #endregion
    /**/
    #region Email
    public string ClearMail(string _mail)
    {
        /*Como el usuario teine acceso a esta parte...
         * deberia de ser un poc mas estricto por lo que que si y que no puede hacer*/

        //Primerodebemos de ver que en el string no exista algun " ' ";
        //string value = _mail.Substring(_mail.IndexOf(_mail));
        if(CleanBase(_mail).Contains("@"))
        {
            return _mail;
        }
        else
        {
            return "";
        }
        
        
    }
    #endregion
    /**/
    #region Password
    public string ClearPass(string _pass)
    {
        return CleanBase(_pass);  //Como es un string  entonces 
    }
    #endregion
    /**/
    #endregion
    /**/
    #region GetDataValue
    public string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }

    IEnumerator DataRecive()
    {
        WWW itemsData = new WWW("http://localhost/Cool_YT_RPG/ItemsData.php");
        yield return itemsData;
        
    }
    #endregion
    /**/
    #endregion

    #region  Opciones General Menu Botones
    /**/
    #region Exit
    public void Exit()
    {
        Application.Quit();
    }
    #endregion
    #region SvaeSemester.net
    public void SSNet()
    {
        /*Aqui llamamos la opcion de dirijirnos al navegador*/
    }
    #endregion
    #region Opciones
    public void Opciones()
    {
        /*Aqui llamamos la funcion para que aparezca nuestro menu de opciones*/
    }
    #endregion
    #region News
    public void News()
    {
        /*Aqui podemos conectarnos a la base de datos para Optener las nuevas entradas*/
    }
    #endregion
    /**/
    #endregion

}
