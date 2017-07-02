using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    #region
    [SerializeField] float currentHealthPoints;
    [SerializeField] float maxHealthPoints = 100f;
    #endregion
   
    // Use this for initialization
    void Start ()
    {
        currentHealthPoints = maxHealthPoints;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public float healthAsPercentage
    {
        get
        {
            return currentHealthPoints / (float)maxHealthPoints;
        }


    }
}
