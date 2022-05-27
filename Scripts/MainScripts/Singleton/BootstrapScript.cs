using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BootstrapScript<T> : MonoBehaviour
    where T : MonoBehaviour
{
    public static T Instance
    {
        get; private set;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = (T)FindObjectOfType(typeof(T));
            DontDestroyOnLoad(gameObject);
            Debug.Log(Instance.name + " loaded");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log(Instance.name + " removed");
        }
    }

}
