using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveandLoad : MonoBehaviour {

    float playGameTime;
    float tempPlayTime;
    


	// Use this for initialization
	void Start () {
        playGameTime = PlayerPrefs.GetFloat("playGameTime", 0f);
        PlayerPrefs.Save();
        tempPlayTime = GameManager.gm.getPlayTime();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
