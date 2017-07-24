using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodscrpt : MonoBehaviour {

    Status status;  


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (!GameManager.gm.isFoodCoolTime()) GetComponentInChildren<grayfood>;
        //else GetComponentInChildren<food>;

	}

    

    void Onclick()
    {
        if (GameManager.gm.isPaused) return;
        if (GameManager.gm.isFoodCoolTime()) return;
        status.updateStatus(0, 20f);
        GameManager.gm.foodAvail = !GameManager.gm.foodAvail;
        GameManager.gm.foodStartTime = GameManager.gm.getPlayTime();
    }
}
