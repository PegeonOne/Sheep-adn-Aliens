using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DogoPackController : MonoBehaviour
{
    public Camera cam;
    GameObject curDogo;
    public RectTransform DogoAbilitiesMenu;

    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {          
            if (hit.transform.gameObject.layer == 3)
            {
                curDogo = hit.transform.gameObject;
                curDogo.SendMessage("SelectDogo", true);
                DogoAbilitiesMenu.gameObject.SetActive(false);
                DogoAbilitiesMenu.position = Input.mousePosition;
                DogoAbilitiesMenu.gameObject.SetActive(true);
            }
            if (curDogo != null && hit.transform.gameObject.layer == 6)
            {
                curDogo.SendMessage("AddTheVector", hit.point);
            }
        }
    }
}
