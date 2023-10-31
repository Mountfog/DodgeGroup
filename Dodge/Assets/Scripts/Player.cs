using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_playerSpeed = 5.0f;
    static float square = 8.4f;
    public AudioSource m_audioSource;
    public AudioClip m_exploseClip;
    public ParticleSystem m_explose;
    public delegate void DelegateFunc(Collision collision);
    public DelegateFunc m_onCollisionEnter = null;

    public void Initialize()
    {
        transform.position = new Vector3(0,transform.position.y,0);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        if (GameMgr.Inst.gameScene.m_battleFSM.IsGameState())
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");
            Vector3 moveV = new Vector3(x, 0, z);
            moveV.Normalize();
            gameObject.GetComponent<Rigidbody>().velocity = moveV * m_playerSpeed;
        }
    }
    public void AddListner(DelegateFunc func)
    {
        m_onCollisionEnter = new DelegateFunc(func);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (m_onCollisionEnter != null)
        {
            m_onCollisionEnter(collision);
        }
    }
}
