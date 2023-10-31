using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.IO;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class TestItem
{
    public int id = 0;
    public string name = string.Empty;
    public int value = 0;
    public TestItem(int kid, string kname, int kvalue)
    {
        SetValue(kid, kname, kvalue);
    }
    public void SetValue(int kid, string kname, int kvalue)
    {
        id = kid; name = kname; value = kvalue;
    }
}

public class FSMtestDlg : MonoBehaviour
{         
    public Button m_btnLoad = null;
    public Button m_btnParsing = null;
    public Button m_bynClear = null;
    public Text m_txtResult = null;
    List<TestItem> listItems = new List<TestItem>();
    private void Awake()
    {
        AssetMgr.Instance.Initialize();
    }
    private void Start()
    {
        m_btnLoad.onClick.AddListener(OnClick_Load);
        m_btnParsing.onClick.AddListener(OnClick_Parsing);
        m_bynClear.onClick.AddListener(OnClick_Clear);
    }
    // Start is called before the first frame update

    public void OnClick_Parsing()
    {
        List<string[]> listdata = CSVParser.Load("TableData/test");
        listItems.Clear();
        for (int i = 1; i < listdata.Count; i++)
        {
            string[] data = listdata[i];
            TestItem kitem = new TestItem(0,"",0);
            int kid = int.Parse(data[0]);
            string kname = data[1];
            int kvalue = int.Parse(data[2]);
            kitem.SetValue(kid,kname,kvalue);
            listItems.Add(kitem);
        }
        m_txtResult.text = string.Empty;
        foreach (TestItem kitem in listItems)
        {
            string s = string.Format("{0} {1} {2}\n", kitem.id, kitem.name, kitem.value);
            m_txtResult.text += s;
        }
    }
    public void OnClick_Load()
    {
        m_txtResult.text = string.Empty;
        List<string[]> listdata = CSVParser.Load("TableData/test");
        for (int i = 0; i < listdata.Count; i++)
        {
            string[] data = listdata[i];
            string s = string.Format("{0} {1} {2}\n", data[0], data[1], data[2]);
            m_txtResult.text += s;
        }
    }
    public void OnClick_Clear()
    {
        m_txtResult.text = string.Empty;
    }
}
