using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StaminaText : MonoBehaviour
{

    private Text Timetext;

    // Use this for initialization
    void Start()
    {
        Timetext = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int intStamina = (int)(GameManager.gm.status.getStatus((int)Status.StatusType.Stamina));
        Timetext.text = "" + intStamina;
    }
}
