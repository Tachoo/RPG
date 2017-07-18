using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Elemental para la gestion se scenas
using System;

public class Get_Characters_List : MonoBehaviour {

   

    public GameObject SlotCharPref;
    public GameObject CharArea;
    public string[] CharactersInfoList;
    [System.Serializable]
    public struct CharacterInfo
    {
        public string nombre;
        public string classe;
        public string nivel;
        public string clan;
        public string id;
    }
    public CharacterInfo InfoChar;
    public List<CharacterInfo> Characters = new List<CharacterInfo>();        //MyList.Add();//Encontre mi salvacion
    public GameObject[] infotochange;
    public GameObject[] Instance;
    public Text [] DataText;


    #region Core
    // Use this for initialization
    void Start ()
    {
        StartCoroutine(CharactersInfo());

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    #endregion
    public void SelectCharacter()
    {

        if (Singleton_Account.instance.Char_ID != 0)
        {
            SceneManager.LoadScene(4);// Creacion de nueva partida
        }


    }//Lomansamos a la siguiente scena solo cuando las flags esten  todas clear ! :v
    public void CreatorMode()
    {
        SceneManager.LoadScene(2);// Creacion de nueva partida
    }


    #region Database
    IEnumerator CharactersInfo()
    {

        WWWForm form = new WWWForm();
        //form.AddField("id", Singleton_Account.instance.AC_ID);
        form.AddField("id", 1);


        WWW itemsData = new WWW("http://www.tachoo.xyz/APIDB/GetCharactersInfo.php", form);

        yield return itemsData;

        string itemsDataString = itemsData.text;
        print(itemsDataString);

        if (itemsDataString.Contains(";"))
        {
            CharactersInfoList = itemsDataString.Split(';');
        }
        SettingData();

        //Como todos son instancias de lo que hay en cada uno entonces digamos que ... infotochange es el boton xD y ocupamos darle un script



    }
    #endregion
    #region DataManipulation
    void SettingData()
    {
        int indexoflist = (int)CharactersInfoList.Length / 5;
       // int n = 1;

       
        //Para hacerlo Modular entonces ocupamos el 
        for (int i = 0; i <(CharactersInfoList.Length-1); i+=5)
        {

            InfoChar.id = CharactersInfoList[i];
            InfoChar.nombre = CharactersInfoList[i + 1];
            InfoChar.classe = CharactersInfoList[i + 2];
            InfoChar.nivel = CharactersInfoList[i + 3];
            InfoChar.clan = CharactersInfoList[i + 4];

            Characters.Add(InfoChar);
        }
        for (int i = 0; i < Characters.Count; i++)
        {
            
            Instantiate(Resources.Load("Slot_Character"), CharArea.transform);
        }
        GetALLTag();
        for (int i = 0; i < infotochange.Length; i++)
        {
            SetInfo(infotochange[i], Characters[i]);

        }
        UpdateACC();

    }

    void GetALLTag()
    {
        
        infotochange = GameObject.FindGameObjectsWithTag("DATABASE"); //Asi solo agarramos los objetos que sebo de cambiar
       
    }

    void SetInfo(GameObject Database, CharacterInfo info)
    {
        DataText = Database.GetComponentsInChildren<Text>();
        
            DataText[0].text = info.nombre;
            DataText[1].text = info.classe;
            DataText[2].text = info.nivel;
            DataText[3].text = info.clan;
        
    }
    #endregion
    #region UI&Button
    void UpdateACC()
    {
        Debug.Log(Instance.Length);
       /*AlaMierda!!! Le paso el boton y despues con el el componente hago que me retorne su padre  o  en general el GameObj y de alli saco lo s componentes de texto*/
        
        Button[] buttons = CharArea.GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnUIButtonClick(button));
        }
        

    }

    private void OnUIButtonClick(Button button)
    {

       Text[] CheckInfo; //Arreglo de Textos

       bool[] Flag = new bool[4]; //Banderas



    CheckInfo=button.gameObject.GetComponentsInChildren<Text>();
        int _ID=0;
        for (int i = 0; i <Characters.Count; i++)
        {
            if ( Characters[i].nombre == CheckInfo[4].text) { Flag[0] = true; _ID = System.Convert.ToInt32(Characters[i].id); } //Sacamos el int
            if ( Characters[i].classe == CheckInfo[5].text) { Flag[1] = true; }
            if ( Characters[i].nivel == CheckInfo[6].text  ) { Flag[2] = true; }
            if ( Characters[i].clan == CheckInfo[7].text ) { Flag[3] = true; }

        }
        if( Flag[0]& Flag[1]& Flag[2]& Flag[3] == true &&_ID!=0) //Condicion mas extra;a XD
        {
            Debug.Log("Terminamos nuestra chamba yeeei");
            Singleton_Account.instance.Char_ID = System.Convert.ToInt32(_ID);
        }

    }
    #endregion
  
}

