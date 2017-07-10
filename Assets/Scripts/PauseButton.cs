using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{

    private Text pauseText;

    // Use this for initialization
    void Start()
    {
        pauseText = GetComponentInChildren<Text>();
        if (GameManager.gm.isPaused) pauseText.text = "Play";
        else pauseText.text = "Pause";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.isPaused) pauseText.text = "Play";
        else pauseText.text = "Pause";
    }

    public void OnClick()
    {
        GameManager.gm.isPaused = !GameManager.gm.isPaused;
    }
}
