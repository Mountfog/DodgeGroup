using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 1.0f;
    public bool m_isLive = true;
    public GameObject m_explosive = null;
    public delegate void DelegateCollision(Collision collision); // 선언부
    public DelegateCollision onCollision = null;                // 정의

    public void Initialize()
    {
        gameObject.transform.position = new Vector3(0, 1.8f, -1);
    }
    void Start()
    {
        playerSpeed = 7.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Update_Move();
    }
    private void Update_Move()
    {
        if (GameMgr.Inst.gameScene.m_battleFSM.IsGameState())
        {
            float z = Input.GetAxis("Vertical");
            float zSpeed = playerSpeed * z * Time.deltaTime;
            float x = Input.GetAxis("Horizontal");
            float xSpeed = playerSpeed * x * Time.deltaTime;
            transform.Translate(xSpeed, 0, zSpeed, Space.World);
        }
    }

    public void AddLinstner(DelegateCollision func )
    {
        onCollision = new DelegateCollision(func);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if( onCollision != null )
            onCollision( collision );
    }
    public void PlayExplosives()
    {
        FXParticle fx = m_explosive.GetComponent<FXParticle>();
        fx.Play();
    }
}

