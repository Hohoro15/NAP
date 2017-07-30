using System.Collections;
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
    [HideInInspector] public float sleepStartTime;
    [HideInInspector] public float sleepTime = 0f;

    //food
    [HideInInspector] public float foodStartTime;    

    //part time job
    [HideInInspector] public float jobStartTime;

    //dog
    [HideInInspector] public bool dogPlaying;
    public void dogStart()
    {
        dogPlaying = true;
    }

    public void dogEnd()
    {
        dogPlaying = false;
    }

    //sink
    [HideInInspector] public bool sink_delay;
    public void sink_start()
    {
    }

    public void sink_check()
    {
    }



    //scene
    public GameObject mainScene;
    public GameObject grayMainScene;



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
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameTime();

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
            status.updateStatus((int)Status.StatusType.Stamina, sleepStaminaPerFrame());
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

    float sleepStaminaPerFrame()
    {
        // fomula: minutes/3600 + 1/15
        return ((sleepTime * MinutesPerPlayTime) / 3600f + 1f / 15f) / framePerMinutes;
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

            if (isSleeping) sleepTime = playTime - sleepStartTime;
            else sleepTime = 0f;
        }
    }

    //second
    public float getPlayTime()
    {
        return playTime;
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
    public void sceneChange(bool what)
    {
        if (!what)
        {
            mainScene.SetActive(false);
            grayMainScene.SetActive(true);
        }
        else
        {
            mainScene.SetActive(true);
            grayMainScene.SetActive(false);
        }
    }

}