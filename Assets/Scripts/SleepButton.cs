using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SleepButton : MonoBehaviour
{

    private Text sleepText;

    // Use this for initialization
    void Start()
    {
        sleepText = GetComponentInChildren<Text>();
        if (GameManager.gm.isSleeping) sleepText.text = "Awake";
        else sleepText.text = "Sleep";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.isSleeping) sleepText.text = "Awake";
        else sleepText.text = "Sleep";
    }

    public void OnClick()
    {
        if (GameManager.gm.isPaused) return;
        if (GameManager.gm.isSleepCoolTime()) return;
        if(!GameManager.gm.isSleeping) GameManager.gm.sleepStartTime = GameManager.gm.getPlayTime();
        GameManager.gm.isSleeping = !GameManager.gm.isSleeping;
    }
}
