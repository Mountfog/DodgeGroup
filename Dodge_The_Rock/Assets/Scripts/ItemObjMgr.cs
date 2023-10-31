using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjMgr : MonoBehaviour
{
    public List<FXSerialize> m_effectList = new List<FXSerialize>();
    public Transform m_prefabparent;
    public Transform m_minRange = null;
    public Transform m_maxRange = null;
    public bool m_kBool = false;

    public void SetReadyState()
    {
        if (m_prefabparent.childCount > 0)
        {
            for (int i = m_prefabparent.childCount; i >= 0; i--)
            {
                Destroy(m_prefabparent.GetChild(i).gameObject);
            }
        }
    }
    public void Initialize()
    {
        m_kBool = false;
        StartCreating();
    }
    void CreateItem()
    {
        int id = Random.Range(1, AssetMgr.Inst.m_assetItems.Count);
        AssetItem assetitem = AssetMgr.Inst.m_assetItems[id - 1];
        AssetStage assetstage = GameMgr.Inst.ginfo.curAssetStage;

        GameObject goPrefab = Resources.Load<GameObject>(assetitem.prefabName);
        GameObject go = Instantiate(goPrefab, this.transform);
        go.transform.localPosition = new Vector3(Random.Range(-7, 7), 0, Random.Range(-7, 7));
        go.gameObject.SetActive(true);
        go.transform.position = RandomPosition();
        ItemObj kitemObj = go.GetComponent<ItemObj>();
        kitemObj.Initialize(id, assetitem.value);
        Destroy(go, assetstage.itemKeepTime);
    }

    void StartCreating()
    {
        m_kBool = true;
        StartCoroutine(RepeatCreatingItem());
    }

    IEnumerator RepeatCreatingItem()
    {
        AssetStage assetstage = GameMgr.Inst.ginfo.curAssetStage;
        while (GameMgr.Inst.gameScene.m_battleFSM.IsGameState() && m_kBool)
        {
            yield return new WaitForSeconds(assetstage.itemAppearDelay);
            CreateItem();
        }
        yield return null;
    }

    Vector3 RandomPosition()
    {
        Vector3 min = m_minRange.transform.position;
        Vector3 max = m_maxRange.transform.position;
        float randomx = Random.Range(min.x, max.x);
        float randomz = Random.Range(min.z, max.z);
        return new Vector3(randomx,1f, randomz);
    }
    
}
