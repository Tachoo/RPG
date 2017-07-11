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
    public string[] Character;
    #region UI Fields
    public InputField User_data;
    public InputField Pass_Data;
    public GameObject Messagebox;
    public Text showmessage;
    #endregion
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    #region Formulario  de Inicio de session y boton de submit
    /**/
    #region Funcion Prinicipal de Inicio de session

    public void LogIn()
    {
        StartCoroutine(Login_SendDataDB(User_data.text, (string)Pass_Data.text));
        //verificamos que el arreglo no este vacio
        
        


    }

   
    #endregion
    /**/
    #region Enumerator para el envio de informacion
    IEnumerator Login_SendDataDB(string user, string pass)
    {
        WWWForm form = new WWWForm();
        form.AddField("user", user);
        form.AddField("pass", pass);

        WWW itemsData = new WWW("http://www.tachoo.xyz/APIDB/UnitytoDB.php",form);

        yield return itemsData;

        string itemsDataString = itemsData.text;
        print(itemsDataString);

        if (itemsDataString.Contains(";"))
        {
            items = itemsDataString.Split(';');
        }
        if (itemsDataString.Contains("|"))
        {
            items = itemsDataString.Split('|');
        }

        DisplayMessageBox();

        if ( System.Convert.ToInt32(items[8])!= 0)
        {
            StartCoroutine(CharacteRecive());
        }
        else
        {
            showmessage.text = "Cuenta no autentificada!\n Favor de autentificarla \n Tips: Algunos servicios de mensajeria consideran nuestros mails como spam \n \tRevisar la banjeda de spam\n\n \tEquipo tecnico de SaveSemestrer2017";

            Messagebox.SetActive(true);
        }


        
        //cuenta regresiva de 3 segundos 
        //loadscene(2);
        /*Antes de ir a otra scena  debermos de confirmar si el usuario tiene  personajes creados o no*/

        // Si tiene personajes creados || Ir al Main Menu del juego o creador de partidas

        //si no tiene personajes creados || Ir al creador de personajes a crear uno 


    }
    #endregion
    #region Enumerator para innerjoin characters
    IEnumerator CharacteRecive()
    {
       
        WWWForm form = new WWWForm();
        form.AddField("id", Singleton_Account.instance.AC_ID);
        

        WWW itemsData = new WWW("http://www.tachoo.xyz/APIDB/GetCharacter.php", form);

        yield return itemsData;

        string itemsDataString = itemsData.text;
        print(itemsDataString);

        if (itemsDataString.Contains(";"))
        {
            Character = itemsDataString.Split(';');
        }

        if (Character.Length > 0)
        {
            //Suponemos que el usuario tiene por lo menos 1 personaje creado debemos de mandarlo al menu principal
            StartCoroutine(loadscene(3));

        }
        else if (Character.Length < 0){}
        else
        {
            //Sabemos que el usurio no tiene personaje creado  entonces debemos de mandarlo al creador de personajes
            StartCoroutine(loadscene(2));
        }


    }
    #endregion
    /**/
    #region Clean Strings
    /**/
    #region CleanBase
    string CleanBase(string _string)
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
     string ClearPass(string _pass)
    {
        return CleanBase(_pass);  //Como es un string  entonces 
    }
    #endregion
    /**/
    #endregion
    /**/
    #region GetDataValue
     string GetDataValue(string data, string index)
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
        Application.OpenURL("www.tachoo.xyz/index.php?page=3");
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
        Application.OpenURL("www.tachoo.xyz/index.php?page=1");
    }
    #endregion
    /**/
    #endregion

    #region Menu&UI custom
    private void DisplayMessageBox()
    {
        if (items.Length>4)//Asumimos que el valor devuelto por la base de datos fue exitosa
        {
            //Hacemoa que el display del texto y demas
            showmessage.text ="Welcome Back Master."+(string)items[2];

            Messagebox.SetActive(true);

            //Mandamos los datos  hacia el singleton Acc Data
            Singleton_Account.instance.IsOnline =true;
            Singleton_Account.instance.AC_Name = items[2]; //Pasamos el nombre  a el singleton
            Singleton_Account.instance.AC_Server = items[5]; // pasamos el server
            Singleton_Account.instance.AC_ID = System.Convert.ToInt32(items[0]); //Pasamos el id como numero de 32 bytes
        }
        else
        {
            string NewMessage = "";

            for (int i = 0; i < items.Length; i++)
                {
                NewMessage+=items[i]+"\n";
                }

            showmessage.text = NewMessage;

            Messagebox.SetActive(true);
        }
        
    }

    public void CloseMessagebox()
    {
        Messagebox.SetActive(false);
    }

    #endregion

    #region loadscene
    IEnumerator loadscene(int index)
    {
        yield return 3;
        SceneManager.LoadScene(index);// Creacion de nueva partida
    }
    #endregion
}
