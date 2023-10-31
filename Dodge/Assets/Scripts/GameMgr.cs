using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameMgr
{
    static GameMgr _inst;
    public static GameMgr Inst
    {
        get
        {
            if( _inst == null )
                _inst = new GameMgr();
            return _inst;
        }
    }
    public GameInfo gInfo = new GameInfo();
    public GameScene gameScene = null;

    public void OnUpdate(float fElapsdTime)
    {
        gInfo.OnUpdate(fElapsdTime);
    }
}
