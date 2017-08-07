using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Questscript : MonoBehaviour {

    public Button quest;
    public Text questMessage;

	// Use this for initialization
	void Start () {
        quest = transform.Find("quest").GetComponent<Button>();
        questMessage = transform.Find("quest").GetComponent<Text>();
        Instantiate(quest, position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnClick()
    {
        switch (questMessage.ToString())
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
