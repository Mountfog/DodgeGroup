using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObjMgrDlg : MonoBehaviour
{
    public Button m_btnPlay = null;
    public Button m_btnPause = null;
    public ItemObjMgr m_itemObjMgr = null;

    private void Awake()
    {
        AssetMgr.Instance.Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_btnPlay.onClick.AddListener(OnClick_Play);
        m_btnPause.onClick.AddListener(OnClick_Pause);
    }

    public void OnClick_Play()
    {
        m_itemObjMgr.Initialize();
    }
    public void OnClick_Pause()
    {
        m_itemObjMgr.m_kBool = false;
    }
    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_itemObjMgr.m_effectList[0].Play();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            m_itemObjMgr.m_effectList[1].Play();
        }
    }
}
