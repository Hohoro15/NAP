using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class state_button : MonoBehaviour {

    
    public GameObject stateWindow;
    private bool windowActive;

    Slider staminaSlider;
    Slider socialitySlider;
    Slider knowledgeSlider;
    Slider willSlider;
    Slider boringSlider;
    Slider moneySlider;

    private float staminaNum;
    private float socialityNum;
    private float knowledgeNum;
    private float willNum;
    private float boringNum;
    private float moneyNum;



	// Use this for initialization
	void Start () {
        stateWindow = transform.Find("StateWindow").gameObject;
        stateWindow.SetActive(false);
        windowActive = false;
        staminaSlider = transform.Find("StateWindow").transform.Find("Stamina").GetComponent<Slider>();
        socialitySlider = transform.Find("StateWindow").transform.Find("Sociality").GetComponent<Slider>();
        knowledgeSlider = transform.Find("StateWindow").transform.Find("Knowledge").GetComponent<Slider>();
        willSlider = transform.Find("StateWindow").transform.Find("Will").GetComponent<Slider>();
        boringSlider = transform.Find("StateWindow").transform.Find("Boring").GetComponent<Slider>();
        moneySlider = transform.Find("StateWindow").transform.Find("Money").GetComponent<Slider>();

    }
	
	// Update is called once per frame
	void Update () {
        if (windowActive)
        {
            staminaNum = GameManager.gm.getStatus(0);
            socialityNum = GameManager.gm.getStatus(1);
            knowledgeNum = GameManager.gm.getStatus(2);
            willNum = GameManager.gm.getStatus(3);
            boringNum = GameManager.gm.getStatus(4);
            moneyNum = GameManager.gm.getStatus(5);

            staminaChange();
            socialityChange();
            knowledgeChange();
            willChange();
            boringChange();
            moneyChange();

        }
        
    }

    public void OnClick()
    {
        stateWindow.SetActive(true);
        windowActive = true;
    }

    public void staminaChange()
    {
        staminaSlider.value = staminaNum;     

    }
    public void socialityChange()
    {
        socialitySlider.value = socialityNum;
        
    }
    public void knowledgeChange()
    {
        knowledgeSlider.value = knowledgeNum;
        
    }
    public void willChange()
    {
        willSlider.value = willNum;
        
    }
    public void boringChange()
    {
        boringSlider.value = boringNum;
        
    }
    public void moneyChange()
    {
        moneySlider.value = moneyNum;
    }
}
