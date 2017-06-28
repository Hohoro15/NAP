using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    //status
    public enum StatusType
    {
        Stamina = 0,
        Sociality = 1,
        Knowledge = 2,
        Will = 3,
        Boring = 4,
        Money = 5,
    };

    private const float maxStatus = 100f;
    private const int listSize = 6;

    //statusList
    private List<float> statusList;
    public List<float> initStatusList;
    
    void Start () {
        Initialized();
    }

    // Update is called once per frame
    void Update () {

    }

    public void Initialized()
    {
        statusList = initStatusList;
    }

    public float getStatus(int index)
    {
        return statusList[index];
    }

    public void updateStatus(int index, float delta)
    {
        statusList[index] += delta;
        if (statusList[index] > maxStatus) statusList[index] = maxStatus;
        if (statusList[index] < 0) statusList[index] = 0;
    }
}
