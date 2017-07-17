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
    
    // Use this for initialization
    void Start ()
    {
        StartCoroutine(CharactersInfo());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectCharacter()
    {
        /*FuckThisShiit Sacamos su nomre y ya despues hacemos una Qry Como estamos en la pc no importa que tentas QeryHagamos internet ilimitado*/

    }


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
            

            //Debug.Log("Class" + CharactersInfoList[i+2] );//Probamos
            //Debug.Log("Nivel" + CharactersInfoList[i+3]);//Probamos
            //Debug.Log("Clan" + CharactersInfoList[i+4]);//Probamos
            Characters.Add(InfoChar);
        }
        for (int i = 0; i < Characters.Count; i++)
        {
            
            Instantiate(Resources.Load("Slot_Character"), CharArea.transform);
            // GameObject instance = Instantiate(Resources.Load("Naruto", typeof(GameObject)),transform.position, Quaternion.identity, transform)as GameObject;
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
        //Ya que se llama despues de crearlos pues aqui tambien jalamos los botones
        //Instance = GameObject.FindGameObjectsWithTag("SLOT");
    }
     void SetInfo(GameObject Database, CharacterInfo info)
    {
        DataText = Database.GetComponentsInChildren<Text>();
        
            DataText[0].text = info.nombre;
            DataText[1].text = info.classe;
            DataText[2].text = info.nivel;
            DataText[3].text = info.clan;
        
    }

    void Validate(int index)
    {
        Text[] CheckInfo;
        bool[] Flag= new bool[4];

        

       
    }
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
        //Nombre del boton o de  el objeto en general
        Debug.Log("Presionado:" + button);
        Text[] CheckInfo; //Arreglo de Textos

        bool[] Flag = new bool[4]; //Banderas

        CheckInfo=button.gameObject.GetComponentsInChildren<Text>();
        for (int i = 0; i < CheckInfo.Length; i++)
        {

           // CheckInfo[i]==?
        }

    }

}

