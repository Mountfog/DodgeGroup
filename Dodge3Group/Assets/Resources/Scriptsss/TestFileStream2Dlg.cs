using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class TestScore
{
    public int no;
    public string name;
    public int score;
}
public class TestFileStream2Dlg : MonoBehaviour
{
    public Button m_btnSave = null;     // A Input UI for Saving Files
    public Button m_btnLoad = null; 
    public Button m_btnClear = null; 
    public Button m_btnAdd = null; 

    public Text m_txtResult = null; // For Outputing Results
    public InputField m_inFiNo = null;
    public InputField m_inFiName = null;
    public InputField m_inFiScore = null;

    List<TestScore> m_listScore = new List<TestScore>();
    // Start is called before the first frame update
    void Start()
    {
        m_btnSave.onClick.AddListener(OnClick_Save);
        m_btnLoad.onClick.AddListener(OnClick_Load);
        m_btnClear.onClick.AddListener(OnClick_Clear);
        m_btnAdd.onClick.AddListener(OnClick_Add);
        m_listScore.Clear();
    }

    public void OnClick_Save()
    {
        FileStream fs = new FileStream("sample2.data", FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Write(m_listScore.Count);
        for(int i=0;i<m_listScore.Count;i++) 
        {
            TestScore kscore = m_listScore[i];
            bw.Write(kscore.no);
            bw.Write(kscore.name);
            bw.Write(kscore.score);
        }
        bw.Close();
        fs.Close();
        m_txtResult.text = "FileSaved";
    }

    public void OnClick_Load()
    {
        try
        {
            FileStream fs = new FileStream("sample2.data",FileMode.Open,FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            m_listScore.Clear();
            int count = br.ReadInt32();
            for(int i = 0; i < count; i++)
            {

                TestScore kscore = new TestScore();
                kscore.no = br.ReadInt32();
                kscore.name = br.ReadString();
                kscore.score = br.ReadInt32();
                m_listScore.Add(kscore);
            }
            br.Close();
            fs.Close();
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
        string str = string.Empty;
        for(int i = 0;i < m_listScore.Count; i++)
        {
            TestScore kscore = m_listScore[i];
            str += string.Format("{0},{1},{2}\n", kscore.no, kscore.name, kscore.score);
        }
        m_txtResult.text = str;
    }
    public void OnClick_Clear()
    {
        m_inFiNo.text = string.Empty;
        m_inFiName.text = string.Empty;
        m_inFiScore.text = string.Empty;
        m_txtResult.text = string.Empty;
    }
    public void OnClick_Add()
    {
        if (string.IsNullOrEmpty(m_inFiNo.text) || string.IsNullOrEmpty(m_inFiName.text) || string.IsNullOrEmpty(m_inFiScore.text))
            return;
        TestScore score = new TestScore();
        score.no = int.Parse(m_inFiNo.text);
        score.name = m_inFiName.text;
        score.score = int.Parse(m_inFiScore.text);
        m_listScore.Add(score);
        m_inFiNo.text = string.Empty;
        m_inFiName.text = string.Empty;
        m_inFiScore.text = string.Empty;
    }
}
