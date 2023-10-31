using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TestPlayerPrefs : MonoBehaviour
{
    //public class TestPlayerPrefs : MonoBehaviour{public Button m_btnSave = null;public Button m_btnLoad = null;public Button m_btnClear = null;public Toggle m_tglBg = null;public Toggle m_tglSFX = null;public Text m_txtResult = null;void Start(){m_btnSave.onClick.AddListener(OnClick_Save);m_btnLoad.onClick.AddListener (OnClick_Load);m_btnClear.onClick.AddListener(OnClick_Clear);}public void OnClick_Save(){PlayerPrefs.SetInt("BG", (m_tglBg.isOn) ? 1 : 0);PlayerPrefs.SetInt("SFX", (m_tglSFX.isOn) ? 1 : 0);m_txtResult.text = "파일이 저장되었습니다";}public void OnClick_Load(){m_tglBg.isOn = (PlayerPrefs.GetInt("BG") == 1);m_tglSFX.isOn = (PlayerPrefs.GetInt("SFX") == 1);m_txtResult.text = "파일을 불러왔습니다";}public void OnClick_Clear(){m_tglBg.isOn = false; m_tglSFX.isOn = false;m_txtResult.text = "상태를 초기화했습니다";}}
    public Button m_btnSave = null;
    public Button m_btnLoad = null;
    public Button m_btnClear = null;
    public Toggle m_tglBg = null;
    public Toggle m_tglSFX = null;
    public Text m_txtResult = null;

    // Start is called before the first frame update
    void Start()
    {
        m_btnSave.onClick.AddListener(OnClick_Save);
        m_btnLoad.onClick.AddListener (OnClick_Load);
        m_btnClear.onClick.AddListener(OnClick_Clear);
    }

    public void OnClick_Save()
    {
        PlayerPrefs.SetInt("BG", (m_tglBg.isOn) ? 1 : 0);
        PlayerPrefs.SetInt("SFX", (m_tglSFX.isOn) ? 1 : 0);
        m_txtResult.text = "파일이 저장되었습니다";
    }
    public void OnClick_Load()
    {
        m_tglBg.isOn = (PlayerPrefs.GetInt("BG") == 1);
        m_tglSFX.isOn = (PlayerPrefs.GetInt("SFX") == 1);
        m_txtResult.text = "파일을 불러왔습니다";
    }
    public void OnClick_Clear()
    {
        m_tglBg.isOn = false;
        m_tglSFX.isOn = false;
        m_txtResult.text = "상태를 초기화했습니다";
    }
}
