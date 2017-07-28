using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bedSlider : MonoBehaviour {

    private Slider slider;
    private Button cancelButton;
    private Button okButton;
    private float sleepLimit; 

	// Use this for initialization
	void Start () {
        slider = GetComponentInChildren<Slider>();
        cancelButton = GetComponentInChildren<Button>();
        okButton = GetComponentInChildren<Button>();
        slider.maxValue = 6f;
        slider.minValue = 0f;
        slider.wholeNumbers = true;
        slider.value = 0f;
       
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.gm.isSleeping)
        {
            if (GameManager.gm.sleepTime == sleepLimit)
            {
                GameManager.gm.isSleeping = false;
                sleepOff();
                GameManager.gm.sceneChange(true);
            }
            
        }
    }

    void OkClick()
    {
        sleepLimit = slider.value;
        GameManager.gm.isSleeping = true;
        GameManager.gm.sleepStartTime = GameManager.gm.getPlayTime();
        GameManager.gm.sceneChange(false);
    }

    void CancelClick()
    {

        GameObject.sleepOff();
    }
}
