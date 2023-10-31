using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject m_bgFrame = null;
    [SerializeField] float rotateSpeed = 0.1f;
    public List<Turret> turrets = new List<Turret>();
    public AssetStage m_assetStage = null;
    public ItemObjMgr m_itemobjmgr = null;
    public GameObject m_BulletList = null;
    public Player m_Player = null;

    private void Start()
    {
        m_Player.AddLinstner(Callback_OnCollision);
        //m_Player.onCollision = new Player.DelegateCollision(Callback_OnCollision);
    }

    public void Initialize()
    {
        m_assetStage = GameMgr.Inst.ginfo.curAssetStage;
        m_Player.Initialize();
        TurretsCountCheck();
        Initialize_Turrets();
        StartCoroutine(BgSpin());
        m_itemobjmgr.Initialize();
        rotateSpeed = 0.01f;
    }
    public void Initialize_Turrets()
    {
        for(int i = 0; i < turrets.Count; i++)
        {
            turrets[i].Initialize();
        }
    }
    IEnumerator BgSpin()
    {
        while (GameMgr.Inst.gameScene.m_battleFSM.IsGameState())
        {
            m_bgFrame.transform.Rotate(0, rotateSpeed, 0);
            yield return null;
        }
        yield return null;
    }
    void TurretsCountCheck()
    {
        for (int i = 0; i < turrets.Count; i++)
        {
            turrets[i].ActiveSelf(true);
        }
        if (m_assetStage.TurretCount <= 7)
        {
            turrets[7].ActiveSelf(false);
        }
        if (m_assetStage.TurretCount <= 6)
        {
            turrets[6].ActiveSelf(false);
        }
        if (m_assetStage.TurretCount <= 5)
        {
            turrets[5].ActiveSelf(false);
        }
        if (m_assetStage.TurretCount == 4)
        {
            turrets[4].ActiveSelf(false);
        }
    }
    public void StopFire(float time)
    {
        for (int i = 0; i < turrets.Count; i++)
        {
            turrets[i].StopFire(time);
        }
    }
    void Callback_OnCollision( Collision col )
    {
        if (GameMgr.Inst.gameScene.m_battleFSM.IsGameState())
        {
            if (col.gameObject.tag == "Bullet")
            {
                Destroy(col.gameObject);
                AssetStage assetStage = GameMgr.Inst.ginfo.curAssetStage;
                GameMgr.Inst.ginfo.actorInfo.HPDamaged(assetStage.bulletAttack);
                m_Player.PlayExplosives();
                if (GameMgr.Inst.ginfo.actorInfo.IsDead())
                {
                    GameMgr.Inst.gameScene.m_battleFSM.SetResultState();
                }
            }
            if (col.gameObject.tag == "Item")
            {
                ItemObj kitemObj = col.gameObject.GetComponent<ItemObj>();

                Destroy(col.gameObject);
                AssetItem assetitem = AssetMgr.Inst.m_assetItems[kitemObj.id - 1];
                //»˙¿Ã∂Û∏È
                if (kitemObj.itemType == 1)
                {
                    GameMgr.Inst.ginfo.actorInfo.HpHealed(assetitem.value);
                    GameMgr.Inst.gameScene.m_gameUI.m_itemobjmgr.m_effectList[1].Play();
                }
                //∆¯≈∫¿Ã∂Û∏È
                else
                {
                    Collider[] m_BulletLists = m_BulletList.GetComponentsInChildren<Collider>();
                    for (int i = 0; i < m_BulletLists.Length; i++)
                    {
                        Destroy(m_BulletLists[i].gameObject);
                    }
                    GameMgr.Inst.gameScene.m_gameUI.StopFire(assetitem.value);
                    GameMgr.Inst.gameScene.m_gameUI.m_itemobjmgr.m_effectList[0].Play();
                }
            }
            if(col.gameObject.tag == "Wall")
            {
                Vector3 pVector = m_Player.transform.position;
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    m_Player.transform.position = pVector + new Vector3(0.1f, 0, 0);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    m_Player.transform.position = pVector + new Vector3(-0.1f, 0, 0);
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    m_Player.transform.position = pVector + new Vector3(0, 0, -0.1f);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    m_Player.transform.position = pVector + new Vector3(0, 0, 0.1f);
                }
            }
        }
    }
}
