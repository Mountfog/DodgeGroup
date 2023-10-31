using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SStage
{
    public int stageNo = 0;
    public int score = 0;
    public SStage(int kstageNo,int kscore)
    {
        score = kscore;
        stageNo = kstageNo;
    }
    public SStage() { }
}
public class SaveInfoDlg : MonoBehaviour
{
    public Button m_btnSave = null;
    public Button m_btnLoad = null;
    public Button m_btnClear = null;
    public Text m_txtResult = null;
    public List<SStage> m_stages = new List<SStage>();
    public int m_highScore = 0;
    public int m_accScore = 0;
    public int m_lastStage = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_btnSave.onClick.AddListener(OnClick_Save);
        m_btnLoad.onClick.AddListener(OnClick_Load);
        m_btnClear.onClick.AddListener(OnClick_Clear);
        m_highScore = 1800;
        m_accScore = 3300;
        m_lastStage = 3;
        m_stages.Add(new SStage(1, 1800));
        m_stages.Add(new SStage(2, 800));
        m_stages.Add(new SStage(3, 700));
        OutputText();
    }
    public void OnClick_Save()
    {
        FileStream fs = new FileStream("test3.data", FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Flush();
        bw.Write(m_highScore);
        bw.Write(m_accScore);
        bw.Write(m_lastStage);
        bw.Write(m_stages.Count);
        for(int i = 0; i < m_stages.Count; i++)
        {
            SStage kstage = m_stages[i];
            bw.Write(kstage.stageNo);
            bw.Write(kstage.score);
        }
        bw.Close();
        fs.Close();
    }
    public void OnClick_Load() 
    {
        try
        {
            FileStream fs = new FileStream("test3.data", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            m_highScore = br.ReadInt32();
            m_accScore = br.ReadInt32();
            m_lastStage = br.ReadInt32();
            int count = br.ReadInt32();
            m_stages.Clear();
            for (int i = 0; i < count; i++)
            {
                SStage kstage = new SStage();
                kstage.stageNo = br.ReadInt32();
                kstage.score = br.ReadInt32();
                m_stages.Add(kstage);
            }
            br.Close();
            fs.Close();
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
        OutputText();
    }
    public void OnClick_Clear() 
    {
        m_txtResult.text = string.Empty;
        m_highScore = m_accScore = m_lastStage = 0;
    }

    public void OutputText()
    {
        string str = string.Format("HighScore : {0}\nAccScore : {1}\nLastStage : {2}\n",m_highScore,m_accScore,m_lastStage);
        for(int i = 0; i < m_stages.Count; i++)
        {
            str += string.Format("{0} stage : {1}\n", m_stages[i].stageNo, m_stages[i].score);
        }
        m_txtResult.text = str;
    }
    
}
