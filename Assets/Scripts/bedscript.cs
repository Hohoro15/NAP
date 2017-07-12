using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedscript : MonoBehaviour {

    private Time Sleeptime;

	// Use this for initialization
	void Start () {
        Sleeptime.time=time
	}
    
	
	// Update is called once per frame
	void Update () {
		if (GameManager.gm.isSleeping) 
	}
    public void Click()
    {
        GameManager.gm.isSleeping=true;

    }
}
