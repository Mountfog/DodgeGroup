using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudUI : MonoBehaviour
{
    public Text m_txtReady = null;
    public StartMenuDlg m_startDlg = null;
    public GameOverDlg m_gameOverDlg = null;
    public Text m_txtTime = null;
    public void Initialize()
    {
       m_startDlg.Initialize();
       m_gameOverDlg.Initialize();
       m_gameOverDlg.AddListner_Restart(OnClick_Restart);
       m_gameOverDlg.AddListner_Menu(OnClick_Menu);
    }
    public void SetReady()
    {
        StartCoroutine(ReadyCor());
    }
    IEnumerator ReadyCor()
    {
        ActivateUI(m_txtReady.gameObject);
        for(int i = 3; i > 0; i--)
        {
            m_txtReady.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        m_txtReady.text = "Start";
        yield return new WaitForSeconds(1);
        GameMgr.Inst.gameScene.m_battleFSM.SetGameState();
        HideUI(m_txtReady.gameObject);
        ActivateUI(m_txtTime.gameObject);
        yield return null;
    }
    public void TimeUpdate()
    {
        float curTime = GameMgr.Inst.gInfo.KeepTime;
        m_txtTime.text = string.Format("Time : {0:00}:{1:00}",curTime / 60, curTime % 60);
    }
    void HideUI(GameObject go)
    {
        go.SetActive(false);
    }
    void ActivateUI(GameObject go)
    {
        go.SetActive(true);
    }
    public void SetResult()
    {
        HideUI(m_txtTime.gameObject);
        m_gameOverDlg.TimeSet();
        ActivateUI(m_gameOverDlg.gameObject);
    }
    public void OnClick_Restart()
    {
        HideUI(m_gameOverDlg.gameObject);
        GameMgr.Inst.gameScene.m_battleFSM.SetReadyState();
    }
    public void OnClick_Menu()
    {
        HideUI(m_gameOverDlg.gameObject);
        ActivateUI(m_startDlg.gameObject);
    }
}

