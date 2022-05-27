using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamScript : MonoBehaviour
{
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sheep")
        {
            other.gameObject.SendMessage("FormTheHerd", false);
            other.gameObject.SendMessage("SetTheRam", this.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sheep")
        {
            other.gameObject.SendMessage("FormTheHerd", true);
        }
    }
}
