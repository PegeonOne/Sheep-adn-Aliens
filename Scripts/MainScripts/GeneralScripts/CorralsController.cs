using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CorralsController : MonoBehaviour
{
    public List<GameObject> sheeps;
    public Transform gate;
    public int sheepID;
    public Vector3 GateClose;

    void Update()
    {
        if (sheeps.Count != 0)
        {
            foreach (GameObject sheep in sheeps.ToList())
            {
                if (sheep.layer != sheepID) sheeps.Remove(sheep);
            }
        }
        if (sheeps.Count == 3)
        {
            gate.localPosition = Vector3.MoveTowards(gate.localPosition, GateClose, Time.deltaTime * 2);
        }       
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject tempObj = other.gameObject;
        sheeps.Add(tempObj);
    }
    private void OnTriggerExit(Collider other)
    {
        sheeps.Remove(other.gameObject);
    }
}
