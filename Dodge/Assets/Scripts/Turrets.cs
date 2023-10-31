using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    public GameObject m_bulletPrefab = null;
    public Transform m_target = null;
    public Transform m_gunPos = null;
    public Transform m_body = null;
    public Transform m_bulletParent = null;
    public Coroutine m_Coroutine = null;
    bool m_isFire = false;
    static float m_shootDelay = 1.5f;
    float bulletSpeed = 5f;

    public void StartFire()
    {
        m_isFire = true;
        if (m_Coroutine == null)
        {
            m_Coroutine = StartCoroutine(TurretFire(m_shootDelay));
        }
    }
    public void StopFire()
    {
        m_isFire = false;
        if (m_Coroutine != null)
        {
            StopCoroutine(m_Coroutine);
            m_Coroutine = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (GameMgr.Inst.gameScene.m_battleFSM.IsGameState())
        {
            m_body.LookAt(m_target);
        }
    }
    IEnumerator TurretFire(float waitTime)
    {
        while (m_isFire)
        {
            yield return new WaitForSeconds(waitTime);
            CreateBullet();
            GetComponent<AudioSource>().Play();
        }
        yield return null;
    }
    public void CreateBullet()
    {
        GameObject go = Instantiate(m_bulletPrefab, m_bulletParent);
        go.transform.position = m_gunPos.position;
        Bullet kbullet = go.GetComponent<Bullet>();
        kbullet.Initialize(m_target, bulletSpeed);
    }
}
