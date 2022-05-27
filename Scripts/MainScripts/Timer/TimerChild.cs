using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerChild : Timer
{
    public override bool SetTimer(float _time)
    {
        _time -= Time.deltaTime;
        if (_time <= 0)
        {
            Debug.Log("Time has over");
            return true;
        }
        else
        {
            Debug.Log(_time);
            return false;
        }
    }
    
}
