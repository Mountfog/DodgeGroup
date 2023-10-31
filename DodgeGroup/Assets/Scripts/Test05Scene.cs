using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test05Scene : MonoBehaviour
{
    public Text m_txtTime = null;
    public Button m_btnStart = null;
    public Button m_btnStop = null;
    public Button m_btnClear = null;
    float fTime = 0;
    bool bTimeOn = false;

    // Start is called before the first frame update
    void Start()
    {
        bTimeOn = false;
        m_btnStart.onClick.AddListener(OnClick_Start);
        m_btnStop.onClick.AddListener(OnClick_Stop);
        m_btnClear.onClick.AddListener(OnClick_Clear);
    }

    // Update is called once per frame
    void Update()
    {
        if(bTimeOn)
        {
            fTime += Time.deltaTime;
        }
        UpdateTimeText();
    }
    void UpdateTimeText()
    {
        int min = (int)fTime / 60;
        int sec = (int)fTime % 60;
        float mili = (fTime - (min * 60 + sec)) * 100;
        string str = string.Format("{0:00}:{1:00}:{2:00}",min,sec,Mathf.Floor(mili));
        m_txtTime.text = str;
    }
    public void OnClick_Start()
    {
        bTimeOn = true;
    }
    public void OnClick_Stop()
    {
        bTimeOn = false;
    }
    public void OnClick_Clear()
    {
        fTime = 0;
    }

}
