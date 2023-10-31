using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudUI : MonoBehaviour
{
    [SerializeField] Text m_readyText = null;
    public PlayerHPUI playerHPUI = null;
    public KeepTimeUI keepTimeUI = null;
    public Text m_stageText = null;
    public Text m_LifeTimeText = null;
    public float m_lifeTime = 0f;
    public ResultSuccessDlg m_resultWinPanel = null;
    public ResultFailedDlg m_resultFailPanel = null;
    public void SetReadyState()
    {
        StartReadyCount();
        playerHPUI.Initialize();
        keepTimeUI.Initalize();
        m_stageText.text = $"{GameMgr.Inst.ginfo.GetCurrentStage()}";
        HideUI(m_resultFailPanel.gameObject);
        HideUI(m_resultWinPanel.gameObject);
    }
    void StartReadyCount()
    {
        StartCoroutine("Readycount");
    }
    IEnumerator Readycount()
    {
        ActivateUI(m_readyText.gameObject);
        int i = 3;
        while (i >= 1)
        {
            m_readyText.text = i.ToString();
            i--;
            yield return new WaitForSeconds(1.0f);

        }
        m_readyText.text = "Start";
        yield return new WaitForSeconds(1.0f);
        HideUI(m_readyText.gameObject);
        GameMgr.Inst.gameScene.m_battleFSM.SetGameState();
        yield return null;
    }
    void ActivateUI(GameObject g)
    {
        g.SetActive(true);
    }
    void HideUI(GameObject g)
    {
        g.SetActive(false);
    }

    public void Result_win()
    {
        m_resultWinPanel.OpenUI();
    }
    public void Result_fail()
    {
        m_resultFailPanel.OpenUI();
    }
    private void Update()
    {
        if (GameMgr.Inst.gameScene.m_battleFSM.IsGameState())
        {
            float lifeTime = GameMgr.Inst.ginfo.m_survivedTime;
            int minute = (int) ((lifeTime + m_lifeTime) / 60);
            int second = (int)((lifeTime + m_lifeTime) % 60);
            m_LifeTimeText.text = string.Format("{0:00}:{1:00}", minute,second);
        }
    }
}
