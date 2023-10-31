using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetMgrDlg : MonoBehaviour
{
    public Button m_btnParsingStage = null;
    public Button m_btnParsingItem = null;
    public Button m_bynClear = null;
    public Text m_txtResult = null;

    private void Awake()
    {
        AssetMgr.Instance.Initialize();
    }
    private void Start()
    {
        m_btnParsingStage.onClick.AddListener(OnClick_Stage);
        m_btnParsingItem.onClick.AddListener(OnClick_Item);
        m_bynClear.onClick.AddListener(onClick_Clear);
    }
    public void OnClick_Stage()
    {
        m_txtResult.text = string.Empty;
        List<AssetStage> stages = AssetMgr.Instance.m_assetStages;
        for(int i=0;i<stages.Count; i++)
        {
            AssetStage kstage = stages[i];
            string s = string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} \n",kstage.id,kstage.fireDelayTime,kstage.bulletSpeed,kstage.keepTime,kstage.playerHp,kstage.bulletAttack,kstage.itemAppearDelay,kstage.itemKeepTime,kstage.turretCount);
            m_txtResult.text += s;
        }
    }
    public void OnClick_Item()
    {
        m_txtResult.text = string.Empty;
        List<AssetItem> items = AssetMgr.Instance.m_assetItems;
        for (int i = 0; i < items.Count; i++)
        {
            AssetItem kitem = items[i];
            string s = string.Format("{0} {1} {2} {3} {4} \n",kitem.id,kitem.itemType,kitem.prefabName,kitem.value,kitem.desc);
            m_txtResult.text += s;
        }
    }
    public void onClick_Clear()
    {
        m_txtResult.text = string.Empty;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
