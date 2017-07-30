using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinkscript : MonoBehaviour
{
    private float sink_playTime;
    public GameObject sink;
    public GameObject sink_cool;

    // Use this for initialization
    void Start()
    {
        sink = transform.Find("sink").gameObject;
        sink_cool = transform.Find("gray_sink").gameObject;
        sink.SetActive(true);
        sink_cool.SetActive(false);
        GameManager.gm.sink_delay = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.isPaused)
            return;
        if (GameManager.gm.dogPlaying && (GameManager.gm.getPlayTime() - sink_playTime > 30f))
            GameManager.gm.dogEnd();

    }

    void OnClick()
    {
        if (GameManager.gm.isPaused) return;

        sink_playTime = GameManager.gm.getPlayTime();
        sink.SetActive(false);
        sink_cool.SetActive(true);
        GameManager.gm.sink_check();
    }
}
