using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class bed_script_ex : MonoBehaviour {

    private GameObject closet;
    private GameObject desk;

    bool isCoolTime;
    
    // Use this for initialization
    void Start () {
        isCoolTime = false;

        closet = transform.GetChild(0).gameObject;
        desk = transform.GetChild(1).gameObject;

    }

    // Update is called once per frame
    void Update () {
		if(isCoolTime)
        {
            closet.SetActive(true);
            desk.SetActive(false);
        }
        else
        {
            closet.SetActive(false);
            desk.SetActive(true);
        }
    }

    public void OnClick()
    {
        isCoolTime = !isCoolTime;
        Debug.Log(isCoolTime);
    }
}
