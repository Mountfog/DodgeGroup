using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TestFileStream : MonoBehaviour
{
    public Button m_btnSave = null;
    public Button m_btnLoad = null;
    public Button m_btnClear = null;
    public Text m_txtResult = null;
    private void Start()
    {
        m_btnSave.onClick.AddListener(OnClick_Save);
        m_btnLoad.onClick.AddListener(OnClick_Load);
        m_btnClear.onClick.AddListener(OnClick_Clear);
    }
    public void OnClick_Save()
    {
        FileStream fs = new FileStream("sample.data", FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Flush();
        int i = 100;
        float f = 123.34f;
        double d = 456789.1234;
        string str = "cafe.naver.com";
        bw.Write(i);
        bw.Write(f);
        bw.Write(d);
        bw.Write(str);
        bw.Close();
        fs.Close();
        m_txtResult.text = "파일을 저장했습니다.";
    }
    public void OnClick_Load()
    {
        int i=0;float f=0;double d=0;string str=string.Empty;
        try{
            FileStream fs = new FileStream("sample.data",FileMode.Open,FileAccess.Read);
            if (fs == null)
                return;
            BinaryReader bw = new BinaryReader(fs);
            i = bw.ReadInt32();
            f = bw.ReadSingle();
            d = bw.ReadDouble();
            str = bw.ReadString();
            bw.Close();
            fs.Close();

        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
        string s = string.Format("{0}\n{1}\n{2}\n{3}", i, f, d, str);
        m_txtResult.text = s;
    }
    public void OnClick_Clear()
    {
        m_txtResult.text = string.Empty;
    }
}

