using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creator_Manager : MonoBehaviour {

    public string CharacterClass;
    private bool NeedUpdate=false;
    public Text HeaderClass;
    public int Genero;
    public int extremo;
    public int temporada;
    public InputField CharacterName;

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
        CharacterClass = "caballero";
        NeedUpdate = true;
        //Cuando se presiona el boton de las classes deberemos de cambiar el contenido de los layers derechos
        StartCoroutine(GetCharacterClassSkills( CharacterClass));
    }
    //Arquero
    public void ClassArquero()
    {
        CharacterClass = "arquero";
        NeedUpdate = true;
        //
        StartCoroutine(GetCharacterClassSkills(CharacterClass));
    }
    //Hechicero
    public void ClassHechicero()
    {
        CharacterClass = "hechicero";
        NeedUpdate = true;
        //
        StartCoroutine(GetCharacterClassSkills(CharacterClass));
    }
    //Monje
    public void ClassMonje()
    {
        CharacterClass = "monje";
        NeedUpdate = true;
        //
        StartCoroutine(GetCharacterClassSkills(CharacterClass));
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
        extremo = 1;
        temporada = 0;
    }
    //Mujer
    public void Temporada()
    {
        extremo = 0;
        temporada = 1;
    }
    #endregion

    #endregion

    #region SendInfo
    public void SendInfo()
    {
        StartCoroutine(CreateCharacter());
    }
    IEnumerator CreateCharacter()
    {
       
        WWWForm form = new WWWForm();
        form.AddField("name",CharacterName.text);
        form.AddField("class",CharacterClass );
        form.AddField("sexo",Genero);
        if (extremo == 0 && temporada == 1)
        {
            form.AddField("season", temporada);
        }
        else if(temporada == 0 && extremo == 1)
        {
            form.AddField("season", extremo);
        }
        
        WWW itemsData = new WWW("http://www.tachoo.xyz/APIDB/GetCaharacterInfo.php", form);

        yield return itemsData;
    }
    #endregion
    #region GetCharacterClassSkills
    IEnumerator GetCharacterClassSkills(string _classname)
    {
        WWWForm form = new WWWForm();
        form.AddField("classname",_classname);
        WWW itemsData = new WWW("http://www.tachoo.xyz/APIDB/GetClassSkills.php", form);

        yield return itemsData;
    }
    #endregion
    #endregion

}
