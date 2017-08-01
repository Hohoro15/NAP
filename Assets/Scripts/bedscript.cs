using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bedscript : MonoBehaviour {

    GameObject bed;
    GameObject gray_bed;
    GameObject pickSleepTime;

    Slider slider;

    private float sleepLimit;
    private bool checkBoxOn;

    // Use this for initialization
    void Start () {
        bed = transform.Find("bed").gameObject;
        gray_bed = transform.Find("gray_bed").gameObject;
        pickSleepTime = transform.Find("pickSleepTime").gameObject;
        sleeping(false);
        pickTime(false);

        GameManager.gm.isSleeping = false;
                        
        slider = transform.Find("pickSleepTime").transform.Find("Slider").GetComponent<Slider>();
        slider.maxValue = 6f;
        slider.minValue = 0f;
        slider.wholeNumbers = true;
        
    }
    
	
	// Update is called once per frame
	void Update () {
        if (GameManager.gm.isPaused) return;
        if (GameManager.gm.isSleeping && (GameManager.gm.getPlayTime() - GameManager.gm.sleepStartTime > sleepLimit)) GameManager.gm.SleepEnd();
        if (GameManager.gm.isSleeping || checkBoxOn) sleeping(true);
        else sleeping(false);
    }

    public void OnClick()
    {
        if (GameManager.gm.isPaused) return;
        if (GameManager.gm.isSleeping) return;
        if (checkBoxOn) return;

        sleeping(true);
        pickTime(true);
        
    }
    public void sleeping(bool sleep)
    {
        bed.SetActive(!sleep);
        gray_bed.SetActive(sleep);
        
    }
    public void pickTime(bool pick)
    {
        pickSleepTime.SetActive(pick);
        checkBoxOn=pick;
    }
   public void OkClick()
    {
        if (GameManager.gm.isPaused) return;
        int hour = (int)slider.value;
        sleepLimit = hour * 30f;
        GameManager.gm.isSleeping = true;
        GameManager.gm.sleepStartTime = GameManager.gm.getPlayTime();
        pickTime(false);
        GameManager.gm.SleepStart(hour);
        GameManager.gm.backgroundOff();
    }

    public void CancelClick()
    {
        if (GameManager.gm.isPaused) return;
        GameManager.gm.backgroundOn();
        pickTime(false);
        sleeping(false);
    }
}
