using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedscript : MonoBehaviour {

    private GameObject bed;
    private GameObject gray_bed;
    private GameObject pickSleepTime;

	// Use this for initialization
	void Start () {
        bed = transform.GetChild(0).gameObject;
        gray_bed = transform.GetChild(1).gameObject;
        pickSleepTime = transform.GetChild(2).gameObject;
        bed.SetActive(true);
        gray_bed.SetActive(false);
        pickSleepTime.SetActive(false);
        GameManager.gm.isSleeping = false;
	}
    
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick()
    {
        if (GameManager.gm.isPaused) return;        
        bed.SetActive(false);
        gray_bed.SetActive(true);        
        pickSleepTime.SetActive(true);
        
    }
    public void sleepOff()
    {
        bed.SetActive(true);
        gray_bed.SetActive(false);
        pickSleepTime.SetActive(false);
    }
}
