using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class CSVParser
{
    public static List<string[]> Load(string sPathName)
    {
        List<string[]> list = new List<string[]>();
        TextAsset kTextAsset = Resources.Load<TextAsset>(sPathName);

        if(kTextAsset == null)
            return null;
        StringReader _reader = new StringReader(kTextAsset.text);
        string inputData = _reader.ReadLine();
        while(inputData != null)
        {
            string[] datas = inputData.Split('\t');
            if (datas.Length == 0)
                continue;
            list.Add(datas);
            inputData = _reader.ReadLine();
        }
        _reader.Close();
        return list;
    }
    public static List<string[]> Load2(string sPathName)
    {
        List<string[]> list = new List<string[]>();
        StreamReader sr = new StreamReader(sPathName);

        if (sr == null) return null;
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            string[] datas = line.Split("\t");
            if(datas.Length == 0)
                continue;
            list.Add(datas);
        }
        sr.Close();
        return list;
    }
}
