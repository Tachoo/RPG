using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] float currentHealthPoints;
    [SerializeField] float maxHealthPoints = 100f;
    // Use this for initialization
    void Start () {
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
