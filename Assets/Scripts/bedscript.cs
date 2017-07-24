using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bedscript : MonoBehaviour {

    private float sleepStartTime;
    private float sleepLength;
    private bool isChecking;

    GameObject bed;
    GameObject bedGray;
    GameObject checkingBox;

    Slider slider;

    Text textTime;
    Text textSleeping;

    // Use this for initialization
    void Start () {
        bed = transform.Find("bed").gameObject;
        bedGray = transform.Find("bed_gray").gameObject;
        checkingBox = transform.Find("checking_box").gameObject;

        textTime = transform.Find("sleep_time").GetComponent<Text>();
        textSleeping = transform.Find("sleeping").GetComponent<Text>();

        slider = transform.Find("checking_box").transform.Find("Slider").GetComponent<Slider>();

        isChecking = false;
        checkingBox.SetActive(false);
        bedOn();
    }


    // Update is called once per frame
    void Update () {
        if (GameManager.gm.isPaused) return;

        if (GameManager.gm.isSleeping && (GameManager.gm.getPlayTime() - sleepStartTime > sleepLength)) GameManager.gm.SleepEnd();

        if (GameManager.gm.isSleeping || isChecking) bedOff();
        else bedOn();

        textSleeping.text = "" + GameManager.gm.isSleeping;
        if (GameManager.gm.isSleeping) textTime.text = "" + (GameManager.gm.getPlayTime() - sleepStartTime).ToString("N2");
        else textTime.text = "0";

    }

    void bedOn()
    {
        bed.SetActive(true);
        bedGray.SetActive(false);
        //Debug.Log("bdon");
    }

    void bedOff()
    {
        bedGray.SetActive(true);
        bed.SetActive(false);
        //Debug.Log("bdoff");
    }

    public void OnClickBed()
    {
        if (GameManager.gm.isPaused) return;
        if (GameManager.gm.isSleeping) return;
        if (isChecking) return;

        checkingBox.SetActive(true);

        isChecking = true;
    }

    public void OnClickSleep()
    {
        if (GameManager.gm.isPaused) return;
        int hour = (int)slider.value;

        sleepLength = hour * 30f;

        sleepStartTime = GameManager.gm.getPlayTime();

        checkingBox.SetActive(false);

        isChecking = false;

        GameManager.gm.SleepStart(hour);
    }

    public void OnClickCancle()
    {
        if (GameManager.gm.isPaused) return;

        GameManager.gm.backgroundOn();

        checkingBox.SetActive(false);

        isChecking = false;
    }
}
