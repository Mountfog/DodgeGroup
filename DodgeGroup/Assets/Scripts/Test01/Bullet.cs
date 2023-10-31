using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float bulletSpeed = 1.0f;
    public Vector3 m_vec = Vector3.zero;

    public void Initialize(Transform ktarget, float speed)
    {
        target = ktarget;
        bulletSpeed = speed;
        transform.LookAt(ktarget);
        m_vec = (ktarget.position - transform.position);
        m_vec.Normalize();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(m_vec * bulletSpeed * Time.deltaTime,Space.World);
    }
}
