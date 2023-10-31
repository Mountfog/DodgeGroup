using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Test04Scene : MonoBehaviour
{
    public Button m_btnStart = null;
    public Button m_btnStop = null;
    public Text m_txtReady = null;
    public GameObject m_startScreenPanel = null;
    public List<Turret3> m_listTurret =new List<Turret3>();

    public void Start()
    {
        //HideUI(m_txtReady.gameObject);
        //ActivateUI(m_startScreenPanel);
        m_btnStart.onClick.AddListener(OnClick_Start);
        m_btnStop.onClick.AddListener(OnClick_Stop);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Test06");
        }
    }
    IEnumerator ReadyCoroutine()
    {
        HideUI(m_startScreenPanel);
        ActivateUI(m_txtReady.gameObject);
        for (int i = 3; i > 0; i--)
        {
            m_txtReady.text = i.ToString();
            m_txtReady.transform.localScale = Vector3.one;
            for (int j = 1; j <= 100; j++)
            {
                float f = Mathf.Lerp(0.5f, 1, 1 - j / 100f);
                m_txtReady.transform.localScale = Vector3.one * f;
                yield return new WaitForSeconds(0.01f);
            }
        }
        m_txtReady.text = "START";
        yield return new WaitForSeconds(1f);
        HideUI(m_txtReady.gameObject);
        yield return null;
    }
    public void OnClick_Start()
    {
        foreach(Turret3 trt in m_listTurret)
        {
            trt.StartFire();
        }
    }
    public void OnClick_Stop()
    {
        foreach (Turret3 trt in m_listTurret)
        {
            trt.StopFire();
        }
    }

    public void HideUI(GameObject go)
    {
        go.SetActive(false);
    }
    public void ActivateUI(GameObject go)
    {
        go.SetActive(true);
    }



}
