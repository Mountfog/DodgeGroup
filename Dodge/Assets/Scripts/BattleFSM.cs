using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleFSM
{
    public delegate void DelegateFunc();

    public class CState
    {
        public DelegateFunc m_onEnterFunc = null;
        public virtual void Initialize(DelegateFunc func)
        {
            m_onEnterFunc = new DelegateFunc(func);
        }
        public virtual void OnEnter() {
            if (m_onEnterFunc != null)
                m_onEnterFunc();
        }
        public virtual void OnUpdate() { }
        public virtual void OnExit() { }
    }
    public class CReadyState : CState
    {
        public override void OnEnter()
        {
            base.OnEnter();
        }
        public override void OnUpdate() { }
        public override void OnExit() { }
    }
    public class CWaveState : CState
    {
        public override void OnEnter()
        {
            if (m_onEnterFunc != null)
                m_onEnterFunc();
        }
        public override void OnUpdate() { }
        public override void OnExit() { }
    }
    public class CGameState : CState
    {
        public override void OnEnter()
        {
            if (m_onEnterFunc != null)
                m_onEnterFunc();
        }
        public override void OnUpdate() { }
        public override void OnExit() { }
    }
    public class CResultState : CState
    {
        public override void OnEnter()
        {
            if (m_onEnterFunc != null)
                m_onEnterFunc();
        }
        public override void OnUpdate() { }
        public override void OnExit() { }
    }
    private CState m_curState = null;
    private CState m_newState = null;

    private CState m_readyState = new CReadyState();
    private CState m_waveState = new CWaveState();
    private CState m_gameState = new CGameState();
    private CState m_resultState = new CResultState();

    public void Initialize(DelegateFunc kReady, DelegateFunc kWave, DelegateFunc kGame, DelegateFunc kResult)
    {
        m_readyState.Initialize(kReady);
        m_waveState.Initialize(kWave);
        m_gameState.Initialize(kGame);
        m_resultState.Initialize(kResult);
    }
    public void OnUpdate()
    {
        if(m_newState != null)
        {
            if(m_curState != null)
                m_curState.OnExit();
            m_curState = m_newState;
            m_newState = null;
            m_curState.OnEnter();
        }
        if(m_curState!= null)
        {
            m_curState.OnUpdate();
        }
    }
    public void SetState(CState kstate)
    {
        m_newState = kstate;
    }
    public void SetReadyState()
    {
        SetState(m_readyState);
    }
    public void SetWaveState()
    {
        SetState(m_waveState);
    }
    public void SetGameState()
    {
        SetState(m_gameState);
    }
    public void SetResultState()
    {
        SetState(m_resultState);
    }
    public bool IsGameState()
    {
        return (m_curState == m_gameState);
    }
}
