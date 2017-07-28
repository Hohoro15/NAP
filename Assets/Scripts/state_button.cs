using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state_button : MonoBehaviour {

    
    public GameObject stateWindow;
    public GameObject staminaSlider;
    public GameObject moneySlider;
    private float staminaNum;
    private float moneyNum;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StaminaChange()
    {
        staminaNum = transform.Find("GameManager").transform.Find("Status").GetComponent<>;

    }
    void MoneyChange()
    {
        moneyNum=
    }
}
