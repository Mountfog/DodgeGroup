using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public GameUI m_gameUI = null;
    public HudUI m_hudUI = null;

    public BattleFSM m_battleFSM = new BattleFSM();
    private void Awake()
    {
        GameMgr.Inst.gameScene = this;
        m_battleFSM.Initialize(CB_Ready,CB_Wave,CB_Game,CB_Result);
    }
    private void Start()
    {
        m_gameUI.Initialize();
        m_hudUI.Initialize();
    }
    public void CB_Ready()
    {
        GameMgr.Inst.gInfo.Initialize();
        m_hudUI.SetReady();
        m_gameUI.SetReady();
    }
    public void CB_Wave()
    {

    }
    public void CB_Game()
    {
        m_gameUI.StartTurrets();
    }
    public void CB_Result()
    {
        m_hudUI.SetResult();
    }
    private void Update()
    {
        if(m_battleFSM != null)
        {
            m_battleFSM.OnUpdate();
        }
        if (m_battleFSM.IsGameState())
        {
            GameMgr.Inst.OnUpdate(Time.deltaTime);
            m_hudUI.TimeUpdate();
        }
    }
}
