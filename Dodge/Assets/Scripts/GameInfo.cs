using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo
{
    private float curKeepTime = 0;

    public void Initialize()
    {
        curKeepTime = 0;
    }
    public void OnUpdate(float delayTime)
    {
        curKeepTime += delayTime;
    }
    public float KeepTime
    {
        get { return curKeepTime; }
    }
}
