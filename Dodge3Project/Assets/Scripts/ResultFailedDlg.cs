using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultFailedDlg : MonoBehaviour
{
    public Text m_txtTime = null;
    public Button m_restartButton;
    public Button m_exitButton;
    public void OpenUI()
    {
        int minute = (int)GameMgr.Inst.ginfo.m_survivedTime / 60;
        int second = (int)GameMgr.Inst.ginfo.m_survivedTime % 60;
        m_txtTime.text = string.Format("{0:00}:{1:00}",minute,second);
        m_restartButton.onClick.AddListener(OnClick_Restart);
        m_exitButton.onClick.AddListener(OnClick_Exit);
        gameObject.SetActive(true);
    }
    void OnClick_Restart()
    {
        GameMgr.Inst.gameScene.m_battleFSM.SetReadyState();
    }
    void OnClick_Exit()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
