using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DogoController : MonoBehaviour
{
    public bool toMove;
    public int pathCount = 3;
    public bool Selected;
    public List<Vector3> path;
    List<DogoController> dogosControllers;
    DogoController currentDogo;
    private void Start()
    {
        pathCount = 3;
        path = new List<Vector3>();
        currentDogo = gameObject.GetComponent<DogoController>();
        dogosControllers = new List<DogoController>();
        dogosControllers = FindObjectsOfType<DogoController>().ToList();
    }
    void Update()
    {
        StartDogoMove();
    }
    public void AddTheVector(Vector3 point)
    {
        if (Selected)
        {
            path.Add(point);
            pathCount--;
            if (pathCount <= 0) toMove = true;
        }   
    }
    public void SelectDogo(bool _select)
    {
        this.Selected = _select;
        foreach (DogoController controllers in dogosControllers)
        {
            if (this.Selected && this.currentDogo != controllers)
            {
                controllers.Selected = false;
            }
        }
    }
    void StartDogoMove()
    {
        if (toMove && path.Count != 0)
        {
            Vector3 point = path[0];
            Vector3 _path = Vector3.MoveTowards(transform.position, point, 10 * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(point - transform.position);
            transform.position = _path;
            if (Vector3.Distance(transform.position, point) <= 0.01f)
            {
                path.Remove(point);
            }
        }
        if (path.Count == 0)
        {
            toMove = false;
            pathCount = 3;
        }
    }
}
