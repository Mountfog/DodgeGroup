using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Test05Dlg : MonoBehaviour
{
    public Button m_btnStart = null;
    public GameObject m_panel = null;
    public Text m_txtReady = null;
    [Header("업데이트에 의해 실행되는가?")]
    public bool byUpdate = false;
    bool isStart = false;
    float time = 0f;
    int count = -1;
    

    void Start()
    {
        isStart = false;
        m_btnStart.onClick.AddListener(OnClick_Start);
    }
    public void OnClick_Start()
    {
        if (byUpdate)
        {
            isStart = true;
            time = 0f;
            count = 3;
        }
        else
            StartCoroutine(StartCor());
    }
    IEnumerator StartCor()
    {
        m_panel.SetActive(false);
        m_txtReady.gameObject.SetActive(true);
        for (int i = 3; i > 0; i--)
        {
            float curtime = 0f;
            float lerptime = 1f;
            float waitTime = 0.05f;
            while(curtime != lerptime)
            {
                m_txtReady.text = i.ToString();
                curtime += waitTime;
                if (curtime > lerptime)
                    curtime = lerptime;
                float t = curtime / lerptime;
                m_txtReady.transform.localScale = Vector3.Lerp(Vector3.one * 2 , Vector3.one , LerpX(t));
                yield return new WaitForSeconds(waitTime);
            }
            yield return null;
        }
        m_txtReady.text = "Start!";
        yield return new WaitForSeconds(1f);
        m_txtReady.gameObject.SetActive(false);
        yield return null;
    }

    float LerpX(float x)
    {
        return (x * x > 0.5f) ? 0.5f : x * x;
    }

    private void Update()
    {
        if (isStart)
        {
            m_panel.SetActive(false);
            m_txtReady.gameObject.SetActive(true);
            m_txtReady.text = (count < 1) ? "Start" :  count.ToString();
            time += Time.deltaTime;
            m_txtReady.transform.localScale = Vector3.Lerp(Vector3.one * 2, Vector3.one, LerpX(time));
            if (time >= 1f)
            {
                time = 0f;
                count -= 1;
            }
            if(count < 0)
            {
                isStart = false;
                m_txtReady.gameObject.SetActive(false);
            }
            
        }
    }
}
