using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerderScript : MonoBehaviour
{
    public Camera camMain;
    float y = 1f;
    LayerMask floorMask = 6;
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        Screen.fullScreen = true;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = camMain.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.layer == floorMask)
            {
                transform.position = new Vector3(hit.point.x, y , hit.point.z);
            }
        }
    }
}
