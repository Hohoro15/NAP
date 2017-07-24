using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class slider_text : MonoBehaviour {

    private Slider slider;
    private Text text;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
        text = transform.Find("Slider_text").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = (int)(slider.value) + " hour";
	}
}
