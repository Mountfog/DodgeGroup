using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletSpeed = 5f;
    Vector3 m_vDir = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(m_vDir * Time.deltaTime * bulletSpeed,Space.World);
    }
    public void Initialize(Transform target, float bSpeed)
    {
        bulletSpeed = 5f;
        m_vDir = target.position - transform.position;
        m_vDir.Normalize();
        transform.LookAt(target);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
