using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBehave : MonoBehaviour, IHerdBehaveImplementation
{
    Transform tr;
    Quaternion rot;
    Vector3 moveTo;
   //[SerializeField] ActionManager actManager;

    [SerializeField] TimerClass timer;
    System.Action sheepAction;
    public int _action;
    public float Angle;
    public float c;
    void Start()
    {
        tr = GetComponent<Transform>();
        sheepAction = ActionToExecute;
    }
    void Update()
    {       
        if (_action == 0) turnSheep();
        if (_action == 1) roamingSheep();
        if (_action == 2) stopSheep();
        if (timer.IsTimerComplete())
        {
            SetTime();
        }
    }

    private void stopSheep()
    {
        Debug.Log("Stop");
    }

    private void roamingSheep()
    {
        moveTo += transform.forward * 0.01f;
        tr.position = moveTo;

    }

    void turnSheep()
    {
        //Debug.Log("Turn");
        rot = Quaternion.Euler(0, Angle, 0);
        tr.rotation = Quaternion.RotateTowards(tr.rotation, rot, 20f * Time.deltaTime);
    }
    public void ActionToExecute()
    {
        _action++;
        Angle = Random.Range(0, 180);
        if (_action > 2) _action = 0;
        Debug.Log(_action);
    }
    public void SetTime()
    {
        c = Random.Range(3, 8);
        timer.SetTimer(c, sheepAction);
    }
}
