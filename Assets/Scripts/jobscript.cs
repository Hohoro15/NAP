using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jobscript : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Onclick()
    {
        if (GameManager.gm.isPaused) return;
        if (GameManager.gm.isJobCoolTime()) return;
        GameManager.gm.jobEffect();        
        GameManager.gm.jobStartTime = GameManager.gm.getPlayTime();
    }
}
