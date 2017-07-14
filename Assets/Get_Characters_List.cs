using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Characters_List : MonoBehaviour {

    public string[] CharactersInfoList;
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
        /*Funcion encargada de  selecionar el character id  de la lista de character info*/

    }


    IEnumerator CharactersInfo()
    {

        WWWForm form = new WWWForm();
        form.AddField("id", Singleton_Account.instance.AC_ID);


        WWW itemsData = new WWW("http://www.tachoo.xyz/APIDB/GetCharactersInfo.php", form);

        yield return itemsData;

        string itemsDataString = itemsData.text;
        print(itemsDataString);

        if (itemsDataString.Contains(";"))
        {
            CharactersInfoList = itemsDataString.Split(';');
        }

       


    }
}

