using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr
{
    static GameMgr _inst = null;
    public static GameMgr Inst
    {
        get
        {
            if (_inst == null)
                _inst = new GameMgr();

            return _inst;
        }
    }

    public void Initialize()
    {
        IsInstalled = true;
        Application.runInBackground = true;
    }

    public GameScene gameScene { get; set; }
    public SaveInfo sinfo = new SaveInfo();
    public GameInfo ginfo = new GameInfo();
    public bool IsInstalled { get; set; }


    public void OnUpdate(float fElapsdTime)
    {
        ginfo.OnUpdate(fElapsdTime);    
    }
}
