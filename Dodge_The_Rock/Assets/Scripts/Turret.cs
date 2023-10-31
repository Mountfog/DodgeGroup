using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform m_target = null;
    public Transform m_body = null;
    public Transform m_bulletPos = null;
    public Transform m_bulletParent = null;
    public GameObject m_bullet;
    public bool m_bFire = false;
    public AssetStage m_assetStage = null;

    public void Initialize()
    {
        m_bFire = true;
        m_assetStage = GameMgr.Inst.ginfo.curAssetStage;
        if (gameObject.activeSelf)
        {
            StartCoroutine("TurretFire");
        }
    }
    public void Fire()
    {
        if (gameObject.activeSelf)
        {
            CreateBullet();
        }
    }
    public void ActiveSelf(bool kbool)
    {
        gameObject.SetActive(kbool);
    }
    public void CreateBullet()
    {
        GameObject go = Instantiate(m_bullet);
        go.transform.parent = m_bulletParent;
        go.transform.position = m_bulletPos.position;

        Bullet kbullet = go.GetComponent<Bullet>();
        int stage = GameMgr.Inst.ginfo.GetCurrentStage();
        AssetStage kstage = AssetMgr.Inst.GetAssetStage(stage);
        kbullet.Initialize(m_target, kstage.bulletSpeed);
    }
    void Update()
    {
        RotateToTarget();
    }
    public void RotateToTarget()
    {
        if (m_target != null)
        {
            m_body.LookAt(m_target);
        }
    }
    IEnumerator TurretFire()
    {
        while (GameMgr.Inst.gameScene.m_battleFSM.IsGameState() && m_bFire)
        {
            Fire();
            int stage = GameMgr.Inst.ginfo.GetCurrentStage();
            AssetStage kstage = AssetMgr.Inst.GetAssetStage(stage);
            yield return new WaitForSeconds(kstage.fireDelayTime);
        }
        yield return null;
    }
    public void StopFire(float time)
    {
        m_bFire = false;
        Invoke("StartTurretFire", time);
    }
    void StartTurretFire()
    {
        m_bFire = true;
        if (gameObject.activeSelf)
        {
            StartCoroutine("TurretFire");
        }
    }
}
