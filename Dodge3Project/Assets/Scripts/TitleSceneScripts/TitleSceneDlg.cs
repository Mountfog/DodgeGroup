using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneDlg : MonoBehaviour
{
    public Button m_startButton = null;
    public Button m_optionsButton = null;
    public Button m_applyButton = null;
    public Button m_cancelButton = null;
    public Toggle m_SFXToggle = null;
    public Toggle m_BGMToggle = null;
    public GameObject m_optionsPanel = null;
    public AudioSource m_BgmAS = null;

    public bool m_BGM = false;
    public bool m_SFX = false;

    private void Start()
    {
        m_startButton.onClick.AddListener(OnClick_Start);
        m_optionsButton.onClick.AddListener(OnClick_Options);
        m_optionsPanel.SetActive(false);
        m_applyButton.onClick.AddListener(OnClick_Apply);
        m_cancelButton.onClick.AddListener(OnClick_Cancel);
        m_SFXToggle.onValueChanged.AddListener((bool b)=>OnValueChanged_SFX(b));
        m_BGMToggle.onValueChanged.AddListener((bool b) => OnValueChanged_BGM(b));
    }


    public void HideUI(GameObject g)
    {
        g.SetActive(false);
    }
    public void OpenUI(GameObject g)
    {
        g.SetActive(true);
    }

    public void OnClick_Start()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnClick_Options()
    {
        OpenUI(m_optionsPanel);
    }
    public void OnClick_Apply()
    {
        HideUI(m_optionsPanel);
    }
    public void OnClick_Cancel()
    {
        HideUI(m_optionsPanel);
    }
    public bool OnValueChanged_SFX(bool b)
    {
        Text t = m_SFXToggle.GetComponentInChildren<Text>();
        if (b)
        {
            t.text = "SFX ON";
        }
        else
        {
            t.text = "SFX OFF";
        }
        return true;
    }
    public bool OnValueChanged_BGM(bool b)
    {
        Text t = m_BGMToggle.GetComponentInChildren<Text>();
        if (b)
        {
            t.text = "BGM ON";
            m_BgmAS.Play();
        }
        else
        {
            t.text = "BGM OFF";
            m_BgmAS.Pause();
        }
        return true;
    }
}
