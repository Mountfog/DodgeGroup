using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3 : MonoBehaviour
{
    public Vector3 m_vDir = Vector3.zero;
    public Transform m_target;
    public float m_bulletSpeed = 1.0f;


    public void Initialize(Transform ktarget, float bSpeed)
    {
        m_target = ktarget;
        m_bulletSpeed = bSpeed;
        transform.LookAt(m_target);
        m_vDir = (m_target.position - transform.position).normalized;
        Destroy(gameObject, 5f);
    }
    private void Update()
    {
        transform.Translate(m_vDir * m_bulletSpeed * Time.deltaTime, Space.World);
    }



}
