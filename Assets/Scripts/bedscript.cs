using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedscript : MonoBehaviour {

	// Use this for initialization
	void Start () {        
	}
    
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Click()
    {
        GameManager.gm.isSleeping=true;

    }
}
