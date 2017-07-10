using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeText : MonoBehaviour {

    private Text Timetext;

    // Use this for initialization
    void Start () {
        Timetext = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        string astr, bstr;
        int a = (int)(GameManager.gm.getPlayTime());
        int b = ((int)(GameManager.gm.getPlayTime() * 100)) % 100;
        astr = "" + a;
        if (b < 10) bstr = "0" + b;
        else bstr = "" + b;
        Timetext.text = astr + "." + bstr;
    }
}
