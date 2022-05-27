using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepScript : MonoBehaviour
{
    public LineRenderer line;
    [Range(0, 5)]
    public float xRadius = 1;
    [Range(0, 5)]
    public float yRadius = 1;
    [Range(0, 50)]
    public int segment = 50;
    public Transform fingerObject;
    bool isDogoInArea, isWall;
    public LayerMask DogoMask;
    public LayerMask Walls;

    Transform wall;

    float radius = 5;
    public Camera cam;
    Vector3 rot;
    float time = 1f;
    float timeforWall = 1f;
    bool continueMove;
    public TimerChild _timer;
    bool roaming = true;
    bool SetParam;
    float Angle, Delay;

    int ActionID;
    void Start()
    {
        line.positionCount = segment + 1;
        line.useWorldSpace = false;
        CreatePoints();
        SetParam = true;
    }

    private void CreatePoints()
    {
        float x, y;
        float angle = 20f;
        for (int i = 0; i < (segment + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xRadius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yRadius;
            line.SetPosition(i, new Vector3 (x, 0, y));
            angle += (360f / segment);
        }
    }

    void Update()
    {
        isDogoInArea = Physics.CheckSphere(transform.position, radius, DogoMask);
        if (isDogoInArea)
        {
            roaming = false;
            continueMove = true;
            time = 1.5f;
        }
        else
        {
            StartTimer();
        }
        if (roaming)
        {
            SetRoaming();
        }
        if (isWall)
        {
            Vector3 shp = new Vector3(transform.position.x, 1.2f, transform.position.z);
            Vector3 walls = new Vector3(wall.transform.position.x, 1.2f, wall.transform.position.z);
            Vector3 target = walls - shp;
            rot = Vector3.RotateTowards(transform.forward, -target, 10f * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(rot);
            transform.position += transform.forward * 0.01f;
            timeforWall -= Time.deltaTime;
            if (timeforWall <= 0)
            {
                timeforWall = 1f;
                isWall = false;
            }
        }
        Movement();
    }

    private void StartTimer()
    { 
        time -= Time.deltaTime;
        if (time <= 0)
        {
            continueMove = false;
            roaming = true;
        }
        
    }
    void Movement()
    {
        if (continueMove)
        {
            Vector3 shp = new Vector3(transform.position.x, 1.2f, transform.position.z);
            Vector3 dog = new Vector3(fingerObject.position.x, 1.2f, fingerObject.position.z);
            Vector3 target = dog - shp;
            rot = Vector3.RotateTowards(transform.forward, -target, 10f * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(rot);
            transform.position += transform.forward * 0.03f;
            StartTimer();
        }     
    }
    void SetRoaming()
    {   
        if (SetParam)
        {
            SetTimeAngle(out Angle, out Delay);
            SetParam = false;          
        }      
        if (RoamingTimer())
        {
            ActionID++;
            SetParam = true;
            if (ActionID >= 3)
            {
                ActionID = 0;
            }
        }       
        Roaming();
    }
    bool RoamingTimer()
    {
        Delay -= Time.deltaTime;
        return Delay <= 0;

    }
    void SetTimeAngle(out float value, out float delay)
    {
        delay = UnityEngine.Random.Range(2f, 4f);
        value = UnityEngine.Random.Range(-140, 140);
    }
    void Roaming()
    {
        if (ActionID == 0)
        {
            
        }
        if (ActionID == 1)
        {
            Quaternion rot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, Angle, 0), 150f * Time.deltaTime);
            transform.rotation = rot;
        }
        if (ActionID == 2)
        {
            transform.position += transform.forward * 0.03f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.gameObject.layer == 10)
        {
            isWall = true;
            wall = collision.transform;
            
        }
    }
    public void FormTheHerd(bool state)
    {
        this.gameObject.GetComponent<SheepScript>().enabled = state;
        this.gameObject.GetComponent<SheepIntoHerd>().enabled = !state;
    }
}
