using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float m_Speed;
    private Vector3 m_vDir = Vector3.forward;

    public void Initialize(Transform kTarget, float kspeed)
    {
        gameObject.SetActive(true);
        m_Speed = kspeed;
        transform.LookAt(kTarget);
        m_vDir = kTarget.position - transform.position;
        m_vDir.Normalize();
        Destroy(gameObject, 5.0f);
    }

    public void Update()
    {
        transform.Translate(m_vDir * m_Speed * Time.deltaTime * 5, Space.World);
    }


}
