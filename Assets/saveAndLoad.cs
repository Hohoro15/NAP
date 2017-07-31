using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveAndLoad : MonoBehaviour {

    int number;
    Text text;

	// Use this for initialization
	void Start ()
    {
        number = PlayerPrefs.GetInt("Number",0);
        PlayerPrefs.Save();
        text = transform.Find("saveText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        text.text = "" + number;
	}

    public void onClickInc()
    {
        number++;
    }

    public void onClickSave()
    {
        PlayerPrefs.SetInt("Number",number);
        PlayerPrefs.Save();
    }
}
