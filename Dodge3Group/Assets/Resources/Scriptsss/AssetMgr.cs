using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class AssetStage
{
    public int id;
    public float fireDelayTime;
    public float bulletSpeed;
    public float keepTime;
    public int playerHp;
    public int bulletAttack;
    public float itemAppearDelay;
    public float itemKeepTime;
    public int turretCount;
}
public class AssetItem
{
    public int id;
    public int itemType;
    public string prefabName;
    public int value;
    public string desc;
}

public class AssetMgr
{
    static AssetMgr instance;
    public static AssetMgr Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new AssetMgr();
            }
            return instance;
        }
    }
    public List<AssetStage> m_assetStages = new List<AssetStage>();
    public List<AssetItem> m_assetItems = new List<AssetItem>();

    public void Initialize()
    {
        Initialize_Stage("TableData/stage");
        Initialize_Item("TableData/item");
    }
    public void Initialize_Stage(string pathName)
    {
        m_assetStages.Clear();
        List<string[]> datas = CSVParser.Load(pathName);
        if (datas == null)
            return;
        for(int i=1;i<datas.Count; i++)
        {
            string[] str = datas[i];
            AssetStage stage = new AssetStage();
            int idx = 0;
            stage.id = int.Parse(str[idx++]);
            stage.fireDelayTime = float.Parse(str[idx++]);
            stage.bulletSpeed = float.Parse(str[idx++]);
            stage.keepTime = float.Parse(str[idx++]);
            stage.playerHp = int.Parse(str[idx++]);
            stage.bulletAttack = int.Parse(str[idx++]);
            stage.itemAppearDelay = float.Parse(str[idx++]);
            stage.itemKeepTime = float.Parse(str[idx++]);
            stage.turretCount = int.Parse(str[idx++]);

            m_assetStages.Add(stage);
        }
        datas.Clear();
    }
    public void Initialize_Item(string pathName)
    {
        m_assetItems.Clear();
        List<string[]> datas = CSVParser.Load(pathName);
        if (datas == null)
            return;
        for (int i = 1; i < datas.Count; i++)
        {
            string[] str = datas[i];
            AssetItem item = new AssetItem();
            int idx = 0;
            item.id = int.Parse(str[idx++]);
            item.itemType = int.Parse(str[idx++]);
            item.prefabName = (str[idx++]);
            item.value = int.Parse(str[idx++]);
            item.desc = (str[idx++]);

            m_assetItems.Add(item);
        }
        datas.Clear();
    }
}
