using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Timer : MonoBehaviour
{
    public virtual bool SetTimer(float time)
    {
        return false;
    }


}
