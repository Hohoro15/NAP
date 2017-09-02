using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Questscript : MonoBehaviour {

    public GameObject quest1;
    public GameObject quest2;
    public GameObject quest3;
    public Text questMessage1;
    public Text questMessage2;
    public Text questMessage3;
    
    private int homeworkNum;
    private int presentNum;
    private int testNum;
    private int interviewNum;

    // Use this for initialization
    void Start () {
        quest1 = transform.Find("quest1").gameObject;
        questMessage1 = transform.Find("quest1").transform.Find("Button").transform.Find("Text").GetComponent<Text>();
        quest2 = transform.Find("quest2").gameObject;
        questMessage2 = transform.Find("quest2").transform.Find("Button").transform.Find("Text").GetComponent<Text>();
        quest3 = transform.Find("quest3").gameObject;
        questMessage3 = transform.Find("quest3").transform.Find("Button").transform.Find("Text").GetComponent<Text>();
        quest1.SetActive(false);
        quest2.SetActive(false);
        quest3.SetActive(false);


    }
	
	// Update is called once per frame
	void Update () {
       

		
	}
    void OnClick1()
    {
        switch (questMessage1.ToString())
        {
            case "과제":
                GameManager.gm.Homework();
                break;
            case "발표":
                GameManager.gm.Presentation();
                break;
            case "시험":
                GameManager.gm.Test();
                break;
            case "면담":
                GameManager.gm.Interview();
                break;
        }
    }
}
