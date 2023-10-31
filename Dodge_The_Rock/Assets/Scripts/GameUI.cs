using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject m_bgFrame = null;
    [SerializeField] float rotateSpeed = 0.1f;
    public List<Turret> m_turretList = new List<Turret>();
    public AssetStage m_assetStage = null;
    public ItemObjMgr m_itemobjmgr = null;
    public GameObject m_BulletList = null;
    public Player m_Player = null;


    public void SetReadyState()
    {
        m_Player.Initialize();
        m_itemobjmgr.SetReadyState();
    }
    public void Initialize()
    {
        m_assetStage = GameMgr.Inst.ginfo.curAssetStage;
        TurretsCountCheck();
        Initialize_m_turretList();
        StartCoroutine(BgSpin());
        m_itemobjmgr.Initialize();
        rotateSpeed = 0.01f;
    }
    private void Start()
    {
        m_Player.AddLinstner(Callback_OnCollision);
        //m_Player.onCollision = new Player.DelegateCollision(Callback_OnCollision);
    }
    public void Initialize_m_turretList()
    {
        for (int i = 0; i < m_turretList.Count; i++)
        {
            m_turretList[i].Initialize();
        }
    }
    public void StopFire(float time)
    {
        for (int i = 0; i < m_turretList.Count; i++)
        {
            m_turretList[i].StopFire(time);
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
        for (int i = 0; i < m_turretList.Count; i++)
        {
            m_turretList[i].ActiveSelf(true);
        }
        if (m_assetStage.TurretCount <= 7)
        {
            m_turretList[7].ActiveSelf(false);
        }
        if (m_assetStage.TurretCount <= 6)
        {
            m_turretList[6].ActiveSelf(false);
        }
        if (m_assetStage.TurretCount <= 5)
        {
            m_turretList[5].ActiveSelf(false);
        }
        if (m_assetStage.TurretCount == 4)
        {
            m_turretList[4].ActiveSelf(false);
        }
    }
    void Callback_OnCollision(Collision col)
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
            if (col.gameObject.tag == "Wall")
            {
                Rigidbody rigidbody = m_Player.GetComponent<Rigidbody>();

                rigidbody.velocity = Vector3.zero;
            }
        }
    }
}
