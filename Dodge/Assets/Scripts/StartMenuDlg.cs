using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuDlg : MonoBehaviour
{
    public Button m_btnStart = null;
    public void Initialize()
    {
        m_btnStart.onClick.AddListener(OnClick_Start);
    }
    public void OnClick_Start()
    {
        GameMgr.Inst.gameScene.m_battleFSM.SetReadyState();
        HideUI(gameObject);
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
