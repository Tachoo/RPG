using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creator_Manager : MonoBehaviour {

    public string CharacterClass;
    private bool NeedUpdate=false;
    public Text HeaderClass;
    public int Genero;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (NeedUpdate)
        {
            //Obtener el UI Rect del text  cambiamos el texto y hacemos false update
            HeaderClass.text = CharacterClass;
            NeedUpdate = false;
        }
	}
    #region CreateCharacter 

    #region Botones&UI

    #region CharacterClass
    //Caballero
    public void ClassCaballero()
    {
        CharacterClass = "Caballero";
        NeedUpdate = true;
    }
    //Arquero
    public void ClassArquero()
    {
        CharacterClass = "Arquero";
        NeedUpdate = true;
    }
    //Hechicero
    public void ClassHechicero()
    {
        CharacterClass = "Hechicero";
        NeedUpdate = true;
    }
    //Monje
    public void ClassMonje()
    {
        CharacterClass = "Monje";
        NeedUpdate = true;
    }
    #endregion

    #region Genero
    //Hombre
    public void Hombre()
    {
        Genero = 1; //--> Hombre es 1
    }
    //Mujer
    public void Mujer()
    {
        Genero = 2; //--> Mujer es 2 
    }
    #endregion
    #region Seasonal
    //Hombre
    public void Extremo()
    {
        Genero = 1; //--> Hombre es 1
    }
    //Mujer
    public void Temporada()
    {
        Genero = 2; //--> Mujer es 2 
    }
    #endregion

    #endregion

    #region SendInfo
    IEnumerable CreateCharacter()
    {
        WWWForm form = new WWWForm();
        //form.AddField("name", );
        //form.AddField("class", );
        //form.AddField("sexo",);
        //form.AddField("season",)
        WWW itemsData = new WWW("http://www.tachoo.xyz/APIDB/GetCaharacterInfo.php", form);

        yield return itemsData;
    }
    #endregion
    #region GetCharacterClassSkills
    WWWForm form = new WWWForm();
    //form.AddField("name", );
    //form.AddField("class", );
    //form.AddField("sexo",);
    //form.AddField("season",)
    WWW itemsData = new WWW("http://www.tachoo.xyz/APIDB/GetCaharacterInfo.php", form);
    #endregion
    #endregion

}
