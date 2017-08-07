using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jobscript : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Onclick()
    {
        if (GameManager.gm.isPaused) return;
        if (GameManager.gm.isJobCoolTime()) return;
        GameManager.gm.jobEffect();        
        GameManager.gm.jobStartTime = GameManager.gm.getPlayTime();
    }
    // Jobcooltime 중이었는지겠죠? 아마 이것도 start time과 끈시각, 다시 킨 시각을 계산하면 되지않을까.
}
