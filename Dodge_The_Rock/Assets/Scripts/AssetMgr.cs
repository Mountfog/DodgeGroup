using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AssetStage
{
    public int id = 0;
    public float fireDelayTime = 0;
    public float bulletSpeed = 0;
    public float keepTime = 0;
    public int playerHp = 0;
    public int bulletAttack = 0;
    public int itemAppearDelay = 0;
    public float itemKeepTime = 0;
    public int TurretCount = 0;
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
    static AssetMgr _inst = null;
    public static AssetMgr Inst
    {
        get
        {
            if (_inst == null)
                _inst = new AssetMgr();

            return _inst;
        }
    }
    public bool IsInstalled { get; set; }
    public List<AssetStage> m_assetStages = new List<AssetStage>();
    public List<AssetItem> m_assetItems = new List<AssetItem>();
    private AssetMgr()
    {
        IsInstalled = false;
    }

    public AssetStage GetAssetStage(int iStage)
    {
        if(iStage > 0 && iStage <= m_assetStages.Count)
        {
            return m_assetStages[iStage-1];
        }
        return null;
    }
    public void Initialize_Stage(string m_tabledata)
    {
        List<string[]> dataList = CSVParser.Load(m_tabledata);

        for (int i = 1; i < dataList.Count; i++)
        {
            string[] data = dataList[i];
            AssetStage kitem = new AssetStage();

            kitem.id = int.Parse(data[0]);
            kitem.fireDelayTime = float.Parse(data[1]);
            kitem.bulletSpeed = float.Parse(data[2]);
            kitem.keepTime = float.Parse(data[3]);
            kitem.playerHp = int.Parse(data[4]);
            kitem.bulletAttack = int.Parse(data[5]);
            kitem.itemAppearDelay = int.Parse(data[6]);
            kitem.itemKeepTime = float.Parse(data[7]);
            kitem.TurretCount = int.Parse(data[8]);

            m_assetStages.Add(kitem);
        }

    }
    public void Initialize_Item(string m_tabledata)
    {
        List<string[]> dataList = CSVParser.Load(m_tabledata);

        for (int i = 1; i < dataList.Count; i++)
        {
            string[] data = dataList[i];
            AssetItem kitem = new AssetItem();

            kitem.id = int.Parse(data[0]);
            kitem.itemType = int.Parse(data[1]);
            kitem.prefabName = data[2];
            kitem.value = int.Parse(data[3]);
            kitem.desc = data[4];

            m_assetItems.Add(kitem);
        }
    }
    public void Initialize()
    {
        Initialize_Stage("TableData/stage");
        Initialize_Item("TableData/item");
        IsInstalled = true;
    }

}

