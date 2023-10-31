using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    public Image m_imageHP = null;
    public Text m_textHP = null;

    public void Initialize()
    {
        ChangedHP();
    }
    public void ChangedHP()
    {
        m_imageHP.fillAmount = (float)GameMgr.Inst.ginfo.actorInfo.HPAmount();
        m_textHP.text = $"{GameMgr.Inst.ginfo.actorInfo.curHP}";
    }
}
