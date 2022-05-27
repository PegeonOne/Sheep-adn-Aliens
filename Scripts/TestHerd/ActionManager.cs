using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class ActionManager : MonoBehaviour
{
    [SerializeField] TimerClass timer;
    Action sheepAction;
    public int _action;
    public float Angle;
    public float c;
    void Start()
    {
        sheepAction = ActionToExecute;
    }
    void ActionToExecute()
    {
        _action++;
        Angle = Random.Range(0, 180);
        if (_action > 2) _action = 0;
        Debug.Log(_action);
    }
    void Update()
    {
        if (timer.IsTimerComplete())
        {
            c = Random.Range(3, 8);
            timer.SetTimer(c, sheepAction);
        }
    }   
}