using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodscrpt : MonoBehaviour {

    private GameObject chicken;
    private GameObject gray_chicken;



	// Use this for initialization
	void Start () {
        chicken = transform.GetChild(0).gameObject;
        gray_chicken = transform.GetChild(1).gameObject;
        chicken.SetActive(true);
        gray_chicken.SetActive(false);
        GameManager.gm.foodStartTime = GameManager.gm.getPlayTime() - 4f;

    }
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.gm.isFoodCoolTime())
            {
                chicken.SetActive(true);
                gray_chicken.SetActive(false);                               
            }
            else
            {
                chicken.SetActive(false);
                gray_chicken.SetActive(true);
            }
        

	}

    

    void Onclick()
    {
        if (GameManager.gm.isPaused) return;
        if (GameManager.gm.isFoodCoolTime()) return;        
        GameManager.gm.foodEffect();      
        GameManager.gm.foodStartTime = GameManager.gm.getPlayTime();
    }
}
