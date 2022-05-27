using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepIntoHerd : MonoBehaviour
{
    Transform ram;
    float distance;
    void Start()
    {
        
    }
    void Update()
    {
        if (ram)
        {
            Vector3 dir = ram.position - transform.position;
            Vector3 rot = Vector3.RotateTowards(transform.forward, dir, 10f * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(rot);
            transform.position = Vector3.Distance(transform.position, ram.position) < distance ? transform.position : transform.position + transform.forward * 0.03f;         
        }
    }
    public void SetTheRam(Transform _ram)
    {
        if(ram == null)
            ram = _ram;
        distance = Random.Range(2.4f, 3.5f);
    }
}
