using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jobscript : MonoBehaviour {

    Status status;

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
        GameManager.gm.status.updateStatus(0, -20f);
        status.updateStatus(5, 40f);        
        GameManager.gm.jobStartTime = GameManager.gm.getPlayTime();
    }
}
