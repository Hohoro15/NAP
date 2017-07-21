using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bedSlider : MonoBehaviour {

    private Slider slider;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnValueChange(int value)
    {
        slider.value = 6f;
    }
}
