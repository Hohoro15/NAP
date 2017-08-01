﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //gm
    public static GameManager gm;
    private static bool GMCreated = false;
    public GameObject gamemanager;
    public static GameObject _gamemanager;

    //Consider pause, second
    private float playTime = 0f;

    //convert to hour
    private const float MinutesPerPlayTime = 2f;
    private const float framePerMinutes = 30f;

    //Pause
    [HideInInspector] public bool isPaused = false;
    private bool pauseLasting = false;
    private float pauseStartTime;
    private float pausedTime = 0f;

    //Status
    private Status status;
    private const float reduceStaminaPerFrame = 10f / framePerMinutes;
    private const float increaseBoringPerFrame = 5f / framePerMinutes;

    //Sleeping
    [HideInInspector] public bool isSleeping = false;
    public List<float> increaseStaminaAmountBySleepPerHour;
    private float increaseStaminaBySleepPerFrame;
    [HideInInspector] public float sleepStartTime;
    

    //food
    [HideInInspector] public float foodStartTime;    

    //part time job
    [HideInInspector] public float jobStartTime;
    

    //scene
    private GameObject mainScene;
    private GameObject grayMainScene;



    void Awake()
    {
        // Prevent gm overlaping
        if (GMCreated == true)
        {
            Destroy(gameObject);
            return;
        }

        Application.targetFrameRate = 60;

        // Remain when scene is changed
        DontDestroyOnLoad(this);

        gm = this;
        _gamemanager = gamemanager;

        status = GetComponentInChildren<Status>();
    }

    // Use this for initialization
    void Start()
    {

        gm.playTime = Time.time;

        // Prevent gm overlaping
        if (GMCreated == true)
            return;
        GMCreated = true;

        mainScene = transform.Find("main scene").gameObject;
        grayMainScene = transform.Find("gray_scene_prev").gameObject;

        backgroundOn();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameTime();

        //이건 왜 지우셨?
        UpdateStatus();
    }

    void UpdateStatus()
    {
        if (isPaused) return;

        UpdateStamina();

        UpdateBoring();
    }

    void UpdateStamina()
    {
        if(isSleeping)
        {
            status.updateStatus((int)Status.StatusType.Stamina, increaseStaminaBySleepPerFrame);
        }
        else
        {
            status.updateStatus((int)Status.StatusType.Stamina, -reduceStaminaPerFrame);
        }
    }

    void UpdateBoring()
    {
        status.updateStatus((int)Status.StatusType.Boring, increaseBoringPerFrame);
    }

    

    // Calculate Time
    void UpdateGameTime()
    {
        if (gm.isPaused)
        {
            if (!pauseLasting)
            {
                pauseLasting = true;
                pauseStartTime = Time.time;
            }
        }
        else
        {
            if (pauseLasting)
            {
                pauseLasting = false;
                pausedTime += Time.time - pauseStartTime;
            }
            playTime = Time.time - pausedTime;
                        
        }
    }

    //second
    public float getPlayTime()
    {
        return playTime;
    }

    //background
    public void backgroundOn()
    {
        mainScene.SetActive(true);
        grayMainScene.SetActive(false);
    }
    public void backgroundOff()
    {
        mainScene.SetActive(false);
        grayMainScene.SetActive(true);
    }

    //food
    public bool isFoodCoolTime()
    {
        if (playTime - foodStartTime < 4f) return true;
        else return false;
    }
    public void foodEffect()
    {
        status.updateStatus(0,20f);
    }
    //job
    public bool isJobCoolTime()
    {
        if (playTime - foodStartTime < 30f) return true;
        else return false;
    }
    public void jobEffect()
    {
        status.updateStatus(0, -20f);
        status.updateStatus(5, 40f);
    }

    //sleep
    public void SleepStart(int hour)
    {
        increaseStaminaBySleepPerFrame = increaseStaminaAmountBySleepPerHour[hour] / (hour * 30f * 60f);
        backgroundOff();
        isSleeping = true;
    }

    public void SleepEnd()
    {
        backgroundOn();
        isSleeping = false;
    }

    //state
    public float getStatus(int index)
    {
        return status.getStatus(index);
    }

}