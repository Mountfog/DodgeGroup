using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TestTextItem
{
    public bool kbool;
    public int kint;
    public float kfloat;
    public string kstring;
    public void Initialize()
    {
        kbool = true;
        kint = 50;
        kfloat = 3.567f;
        kstring = "æ»≥Á«œººø‰";
    }
}
public class TestTextDlg : MonoBehaviour
{
    public Button m_btnSave = null;
    public Button m_btnLoad = null;
    public Button m_btnClear = null;
    public Text m_txtResult = null;
    public TestTextItem m_item = new TestTextItem();
    // Start is called before the first frame update
    void Start()
    {
        m_item.Initialize();
        m_btnSave.onClick.AddListener(OnClick_Save);
        m_btnLoad.onClick.AddListener(OnClick_Load);
        m_btnClear.onClick.AddListener(OnClick_Clear);
    }

    void OnClick_Save()
    {
        StreamWriter sw = new StreamWriter("saveinfo.txt");
        sw.Flush();
        sw.WriteLine(m_item.kbool);
        sw.WriteLine(m_item.kint);
        sw.WriteLine(m_item.kfloat);
        sw.WriteLine(m_item.kstring);
        sw.Close();
    }
    void OnClick_Load()
    {
        try
        {
            
            StreamReader sr = new StreamReader("saveinfo.txt");
            if (sr == null)
                return;
            m_item = new TestTextItem();
            m_item.kbool = bool.Parse(sr.ReadLine());
            m_item.kint = int.Parse(sr.ReadLine());
            m_item.kfloat = float.Parse(sr.ReadLine());
            m_item.kstring = sr.ReadLine();
            sr.Close();

        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
        string s = string.Format("{0}\n{1}\n{2}\n{3}", m_item.kbool, m_item.kint, m_item.kfloat, m_item.kstring);
        m_txtResult.text = s;
    }
    void OnClick_Clear()
    {
        m_txtResult.text = string.Empty;
    }
    void SaveInfo(string path, string fName) //Practice
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string pathName = path + "/" + fName;
        StreamWriter sw = new StreamWriter(pathName);
        sw.Close();
    }
}
