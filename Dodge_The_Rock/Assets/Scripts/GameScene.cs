using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public GameUI m_gameUI;
    public HudUI m_hudUI;

    [HideInInspector] public BattleFSM m_battleFSM = new BattleFSM();

    private void Awake()
    {
        AssetMgr.Inst.Initialize();
        GameMgr.Inst.Initialize();
        GameMgr.Inst.gameScene = this;
        GameMgr.Inst.ginfo.Initialize();
        GameMgr.Inst.sinfo.LoadData();
    }
    // Start is called before the first frame update
    void Start()
    {
        m_battleFSM.Initialize(CB_Ready, CB_Game, CB_Result);
        GameMgr.Inst.gameScene.m_battleFSM.SetReadyState();
        GameMgr.Inst.ginfo.SetStage(1);
    }
    void CB_Ready()
    {
        GameMgr.Inst.ginfo.Initialize();
        GameMgr.Inst.sinfo.Initialize();
        m_gameUI.SetReadyState();
        m_hudUI.SetReadyState();
    }
    void CB_Game()
    {
        m_gameUI.Initialize();
    }
    void CB_Result()
    {
        Debug.Log("ResultState");
        if (GameMgr.Inst.ginfo.actorInfo.IsDead())
        {
            m_hudUI.Result_fail();
        }
        else
        {
            m_hudUI.Result_win();
        }
        GameMgr.Inst.sinfo.SaveData();
    }
    private void Update()
    {
        if(m_battleFSM != null)
        m_battleFSM.OnUpdate();
        if (m_battleFSM.IsGameState())
            GameMgr.Inst.OnUpdate(Time.deltaTime);
    }
}
