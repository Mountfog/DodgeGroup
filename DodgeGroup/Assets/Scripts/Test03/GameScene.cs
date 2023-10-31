using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{

    public List<Turret3> m_turretList = new List<Turret3>();
    public Button m_btnStart = null;
    public Button m_btnStop = null;



    public void Start()
    {
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
    public void OnClick_Start()
    {
        StartTurrets();
    }
    public void OnClick_Stop()
    {
        StopTurrets();
    }
    public void StartTurrets()
    {
        for(int i = 0; i < m_turretList.Count; i++)
        {
            m_turretList[i].StartFire();
        }

    }
    public void StopTurrets()
    {
        for (int i = 0; i < m_turretList.Count; i++)
        {
            m_turretList[i].StopFire();
        }
    }

}
