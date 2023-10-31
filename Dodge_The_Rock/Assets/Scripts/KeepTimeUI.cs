using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepTimeUI : MonoBehaviour
{
    public Text m_textTime = null;
    public Image m_imageTime = null;
    public bool m_bAction = false;
    // Start is called before the first frame update
    public void Initalize()
    {
        m_bAction = true;
    }

    private void Update()
    {
        if (m_bAction)
        {
            m_imageTime.fillAmount = 1f - GameMgr.Inst.ginfo.TimeAmount();
            m_textTime.text = string.Format("{0}",(int)GameMgr.Inst.ginfo.m_curKeepTime);
        }
    }


}
