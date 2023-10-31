using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Turret : MonoBehaviour
{
    public Transform m_target = null;
    public Transform m_body = null;
    public Transform m_gunPos = null;
    public Transform m_bulletParent = null;
    public GameObject m_prefabBullet = null;
    public float bulletSpeed = 10f;
    public bool m_isFire = false;

    private void Start()
    {
        m_isFire = true;
        StartCoroutine(FireFunc());
    }
    public void Stop()
    {
        m_isFire = false;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateBullet();
        }
    }

    void CreateBullet()
    {
        GameObject go = Instantiate(m_prefabBullet, m_bulletParent);
        go.transform.position = m_gunPos.position;
        Bullet3 kbullet = go.GetComponent<Bullet3>();
        kbullet.Initialize(m_target,bulletSpeed);
    }
}
