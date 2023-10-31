using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test02Dlg : MonoBehaviour
{
    public Player2 m_player = null;
    public Turret2 m_turret = null;
    public Button m_btnStart = null;
    public Button m_btnStop = null;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        m_btnStart.onClick.AddListener(OnClick_Start);
        m_btnStop.onClick.AddListener(OnClick_Stop);
    }
    public void OnClick_Start()
    {
        m_turret.StartFire();
    }
    public void OnClick_Stop()
    {
        m_turret.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Test06");
        }
    }
}
