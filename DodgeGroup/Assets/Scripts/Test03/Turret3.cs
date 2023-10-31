using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret3 : MonoBehaviour
{
    public Transform m_body;
    public Transform m_gunPos;
    public Transform m_bulletParent;
    public Transform m_bulletTarget;
    public GameObject m_prefabBullet;
    public float bulletSpeed = 10.0f;
    public Coroutine m_cproutine = null;
    bool m_isFire = false;
    public float m_shootDelay = 1f;
    public AudioSource m_source = null;
    public AudioClip clipGun = null;
    public void Initialize(Transform ktarget, Transform kparent)
    {
        m_bulletTarget = ktarget;
        m_bulletParent = kparent;
    }
    public void StartFire()
    {
        m_isFire = true;
        m_cproutine ??= StartCoroutine(TurretCoroutine(m_shootDelay));
    }
    public void StopFire()
    {
        m_isFire = false;
        if (m_cproutine != null)
        {
            StopCoroutine(m_cproutine);
            m_cproutine = null;
        }
    }

    private void Update()
    {
        m_body.LookAt(m_bulletTarget);
    }
    void CreateBullet()
    {
        GameObject go = Instantiate(m_prefabBullet, m_bulletParent);
        go.transform.position = m_gunPos.position;
        Bullet3 kbullet = go.GetComponent<Bullet3>();
        kbullet.Initialize(m_bulletTarget, bulletSpeed);
    }
    IEnumerator TurretCoroutine(float bDelayTime)
    {
        while (m_isFire)
        {
            CreateBullet();
            m_source.PlayOneShot(clipGun);
            yield return new WaitForSeconds(bDelayTime);
        }
        yield return null;
    }
}
