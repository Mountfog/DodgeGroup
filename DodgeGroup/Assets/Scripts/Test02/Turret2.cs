using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret2 : MonoBehaviour
{
    public Transform m_target = null;
    public Transform m_body = null;
    public Transform m_gunPos = null;
    public Transform m_bulletParent = null;
    public GameObject m_prefabBullet = null;
    public float bulletSpeed = 10f;
    public bool m_isFire = false;
    Coroutine m_coroutine;

    public void StartFire()
    {
        
        m_isFire = true;
        if(m_coroutine == null)
        {
            m_coroutine = StartCoroutine(FireFunc());
        }
    }
    public void Stop()
    {
        m_isFire = false;
        if(m_coroutine != null)
        {
            StopCoroutine(m_coroutine);
            m_coroutine = null;
        }


    }
    IEnumerator FireFunc()
    {
        while (m_isFire)
        {
            yield return new WaitForSeconds(1f);
            CreateBullet();
        }
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        m_body.LookAt(m_target);
    }

    void CreateBullet()
    {
        GameObject go = Instantiate(m_prefabBullet, m_bulletParent);
        go.transform.position = m_gunPos.position;
        Bullet3 kbullet = go.GetComponent<Bullet3>();
        kbullet.Initialize(m_target, bulletSpeed);
    }
}
