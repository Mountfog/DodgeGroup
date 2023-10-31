using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestFXSerialize : MonoBehaviour
{
    public GameObject m_prefab = null;
    public Button m_btnPlay = null;
    public Button m_btnStop = null;
    // Start is called before the first frame update
    void Start()
    {
        m_btnPlay.onClick.AddListener(OnClick_Play);
        m_btnStop.onClick.AddListener(OnClick_Stop);
    }

    public void OnClick_Play()
    {
        FXSerialize fx = m_prefab.GetComponent<FXSerialize>();
        fx.Play();
    }
    public void OnClick_Stop()
    {
        FXSerialize fx = m_prefab.GetComponent<FXSerialize>();
        fx.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
