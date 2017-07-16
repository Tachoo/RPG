using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Elemental para la gestion se scenas

public class Creator_Manager : MonoBehaviour {

    private int classtype;
    #region DataSend
    public string CharacterClass;
    private bool NeedUpdate=false;
    public int Genero;
    public int extremo;
    public int temporada;
    #region CharacterName
    public InputField CharacterName;
    #endregion
    //
    #endregion
    #region  DataBaseContainer
    public string[] Skills;
    #endregion
    #region  UIFields
    //ClassHeader
    public Text HeaderClass;

    //Skills
    #region Skills Text Header
    public Text Skill1;

    public Text Skill2;

    public Text Skill3;

    public Text Skill4;
    #endregion

    #endregion

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
        classtype = 1;
    }
    //Arquero
    public void ClassArquero()
    {
        CharacterClass = "arquero";
        NeedUpdate = true;
        //
        StartCoroutine(GetCharacterClassSkills(CharacterClass));
        classtype = 2;
    }
    //Hechicero
    public void ClassHechicero()
    {
        CharacterClass = "hechicero";
        NeedUpdate = true;
        //
        StartCoroutine(GetCharacterClassSkills(CharacterClass));
        classtype = 3;
    }
    //Monje
    public void ClassMonje()
    {
        CharacterClass = "monje";
        NeedUpdate = true;
        //
        StartCoroutine(GetCharacterClassSkills(CharacterClass));
        classtype = 4;
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
    public void CreateCharacterDB()
    {
        StartCoroutine(CreateCharacter());
        //ya que termino de mandar los datos a la base de datos entonces lo mandamos a seleccionar su campeon uwu. 
       

    }
    IEnumerator CreateCharacter()
    {
       
        WWWForm form = new WWWForm();
        form.AddField("id", Singleton_Account.instance.AC_ID);
        form.AddField("name",CharacterName.text);
        form.AddField("class", classtype);
        form.AddField("gender",Genero);
        form.AddField("season", temporada);
        form.AddField("hardcore", extremo);

        
        WWW itemsData = new WWW("http://www.tachoo.xyz/APIDB/CreateCharacter.php", form);

        yield return itemsData;

        StartCoroutine(loadscene(3));
    }
    #endregion
    #region GetCharacterClassSkills
    IEnumerator GetCharacterClassSkills(string _classname)
    {
        WWWForm form = new WWWForm();
        form.AddField("classname",_classname);
        WWW itemsData = new WWW("http://www.tachoo.xyz/APIDB/GetClassSkills.php", form);

        yield return itemsData;

        //Debemos de asegurarnos que no sea vacio el string;
        if (itemsData.text.Length != 0)
        {
            //Si tiene algo entonces debemos de acomodar la informacion 
            //string temporal donde agarramos toda la info
            string itemsDataString = itemsData.text;
            print(itemsDataString);

            if (itemsDataString.Contains(";"))
            {
                Skills = itemsDataString.Split(';');
            }
            //Ya que lo ordenamos debemos de pensar en un algoritmo en el cual  evite el id  y el nombre de la skill y la descripcion sea 1 
            //Solo son 4 habilidades ... so deberia de pensar en  4 ... creo que se los pondremos manuales... creo que no van a cambiar

            Skill1.text = Skills[1]  +":\t"+Skills[2] +"\t Type:"+Skills[3];
            Skill2.text = Skills[5]  +":\t"+Skills[6] +"\t Type:"+Skills[7];
            Skill3.text = Skills[9]  +":\t"+Skills[10]+"\t Type:"+Skills[11];
            Skill4.text = Skills[13] +":\t"+Skills[14]+"\t Type:"+Skills[15];

        }
        else
        {
            //Si no tiene nada debriamos no hacer nada
        }


    }
    #endregion
    #endregion
    IEnumerator loadscene(int index)
    {
        yield return 3;
        SceneManager.LoadScene(index);// Creacion de nueva partida
    }
}
