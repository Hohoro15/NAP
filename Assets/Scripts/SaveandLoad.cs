using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveandLoad : MonoBehaviour {

    float playGameTime;
    

	// Use this for initialization
	void Start () {
        playGameTime = PlayerPrefs.GetFloat("playGameTime", 0f);
        PlayerPrefs.Save();
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnSaveClick()
    {
        PlayerPrefs.SetFloat("playGameTime", GameManager.gm.getPlayTime());
        PlayerPrefs.Save();
    }
}
