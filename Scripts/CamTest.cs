using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTest : MonoBehaviour
{
    Camera cam;
    float time = 0.2f;
    int posCount = 0;
    public LineRenderer lineR;
    public Vector3[] P;
    Vector3[] buffer;
    public Vector3[] buffer2;
    void Start()
    {
        cam = GetComponent<Camera>();
        buffer = new Vector3[4];
        buffer2 = new Vector3[21];
        P = new Vector3[4];
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            time -= Time.deltaTime;

            if (Physics.Raycast(ray, out hit) && time <= 0)
            {
                time = 0.1f;
                Vector3 a = new Vector3(hit.point.x, 1, hit.point.z);
                P[posCount] = a;
                posCount++;
                if (posCount > 3) 
                {
                    posCount = 0;
                    lineR.positionCount += 20;                   
                    for (int i = 0; i < 4; i++)
                    { 
                        buffer[i] = P[i];                       
                    }
                    int n = 0;
                    for (float t = 0; t <= 1; t += 0.05f)
                    {
                        Vector3 C = Mathf.Pow((1 - t), 3) * buffer[0] + 3 * Mathf.Pow((1 - t), 2) * t * buffer[1] + 3 * (1 - t) * (t * t) * buffer[2] + (t * t * t) * buffer[3];
                        buffer2[n] = C;
                        n++;
                    }
                    int id = lineR.positionCount - 20;
                    for (int i = 0; i < 20; i++)
                    {
                        lineR.SetPosition(id, buffer2[i]);
                        //Debug.Log(id);
                        id++;       
                    }
                }   
            }          
        }
    }
}
