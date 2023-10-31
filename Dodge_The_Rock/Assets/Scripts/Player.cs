using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 1.0f;
    public bool m_isLive = true;
    public GameObject m_explosive = null;
    public delegate void DelegateCollision(Collision collision); 
    public DelegateCollision onCollision = null;              

    public void Initialize()
    {
        gameObject.transform.position = new Vector3(0, 1.8f, -3);
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
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");
            Vector3 moveV = new Vector3(x, 0, z);
            moveV.Normalize();
            gameObject.GetComponent<Rigidbody>().velocity = moveV * playerSpeed;
        }
        if (GameMgr.Inst.gameScene.m_battleFSM.IsResultState())
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    public void AddLinstner(DelegateCollision func)
    {
        onCollision = new DelegateCollision(func);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (onCollision != null)
            onCollision(collision);
    }
    public void PlayExplosives()
    {
        FXParticle fx = m_explosive.GetComponent<FXParticle>();
        fx.Play();
    }
}
