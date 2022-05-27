using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerClass : MonoBehaviour
{
    Action timerCallBack;
    float time;
    public void SetTimer(float time, Action timerCallBack)
    {
        this.time = time;
        Debug.Log("Time " + time);
        this.timerCallBack = timerCallBack;
    }
    void Update()
    {
        if (time > 0) { 
            time -= Time.deltaTime;
            if (IsTimerComplete()) timerCallBack(); 
        }
    }
    public bool IsTimerComplete()
    {
        return time <= 0f;
    }
}
