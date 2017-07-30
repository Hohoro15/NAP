using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogscript : MonoBehaviour
{
    private float dog_playTime;
    public GameObject dog;
    public GameObject sleeping_dog;

    // Use this for initialization
    void Start()
    {
        dog = transform.Find("dog").gameObject;
        sleeping_dog = transform.Find("sleeping_dog").gameObject;
        dog.SetActive(true);
        sleeping_dog.SetActive(false);
        GameManager.gm.dogPlaying = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.isPaused)
            return;
        if (GameManager.gm.dogPlaying && (GameManager.gm.getPlayTime() - dog_playTime > 30f))
            GameManager.gm.dogEnd();

    }

    void OnClick()
    {
        if (GameManager.gm.isPaused) return;

        dog_playTime = GameManager.gm.getPlayTime();
        dog.SetActive(false);
        sleeping_dog.SetActive(true);
        GameManager.gm.dogStart();
    }
}
