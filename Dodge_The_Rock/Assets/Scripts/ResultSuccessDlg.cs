using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ResultSuccessDlg : MonoBehaviour
{
    public Text m_textStage = null;
    public Text m_textCurScore = null;
    public Text m_textAccScore = null;
    public Text m_TextHighScore = null;
    public Button m_restartButton = null;
    public Button m_nextButton = null;
    public Button m_exitButton = null;

    public void OpenUI()
    {
        var gameInfo = GameMgr.Inst.ginfo;
        GameMgr.Inst.gameScene.m_hudUI.m_lifeTime += GameMgr.Inst.ginfo.m_keepTime;
        m_restartButton.onClick.AddListener(OnClick_Restart);
        m_nextButton.onClick.AddListener(OnClick_Next);
        m_exitButton.onClick.AddListener(OnClick_Exit);
        float per = gameInfo.actorInfo.HPAmount();
        m_textCurScore.text = $"Score : {gameInfo.CurCalculateScore()}";
        m_textAccScore.text = $"Total : {GameMgr.Inst.sinfo.totalScore}";
        m_TextHighScore.text = $"HighScore : {GameMgr.Inst.sinfo.GetHighScore()}";
        m_textStage.text = $"Stage {gameInfo.GetCurrentStage()} Clear";
        gameObject.SetActive(true);
    }
    public void OnClick_Restart()
    {
        GameMgr.Inst.gameScene.m_battleFSM.SetReadyState();
    }
    public void OnClick_Next()
    {
        GameMgr.Inst.ginfo.GotoNextStage();
        GameMgr.Inst.gameScene.m_battleFSM.SetReadyState();
    }
    public void OnClick_Exit()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
