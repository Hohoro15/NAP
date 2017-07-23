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
       
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.gm.sleepTime == sleepLimit)
        {

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
        
        bedscript.bed.SetActive(true);
        bedscript.gray_bed.SetActive(true);
        pickSleepTime.SetActive(true);
    }
}
