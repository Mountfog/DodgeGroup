using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDlg : MonoBehaviour
{
    public delegate void ButtonFunc();
    public ButtonFunc onBtnRestart = null;
    public ButtonFunc onBtnMenu = null;
    public Text m_txtTime = null;
    public Button m_btnRestart = null;
    public Button m_btnMenu = null;

    public void Initialize()
    {
        m_btnRestart.onClick.AddListener(OnClick_Restart);
        m_btnMenu.onClick.AddListener(OnClick_Menu);
    }
    public void TimeSet()
    {
        float curTime = GameMgr.Inst.gInfo.KeepTime;
        m_txtTime.text = string.Format("{0:00}:{1:00}", curTime / 60, curTime % 60);
    }
    public void AddListner_Restart(ButtonFunc func)
    {
        onBtnRestart = new ButtonFunc(func);
    }
    public void AddListner_Menu(ButtonFunc func)
    {
        onBtnMenu = new ButtonFunc(func);
    }
    public void OnClick_Restart()
    {
        if(onBtnRestart != null)
            onBtnRestart();
    }
    public void OnClick_Menu() 
    {
        if(onBtnMenu != null)
            onBtnMenu();
        
    }
    void HideUI(GameObject go)
    {
        go.SetActive(false);
    }
    void ActivateUI(GameObject go)
    {
        go.SetActive(true);
    }
}
