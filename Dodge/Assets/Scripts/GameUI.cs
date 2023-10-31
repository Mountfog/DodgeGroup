using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public Player m_player = null;
    public List<Turrets> m_turretList = new List<Turrets>();
    public GameObject m_BG = null;
    public void Initialize()
    {
        m_player.AddListner(PlayerCollision);
    }
    public void SetReady()
    {
        m_player.Initialize();
    }
    public void StartTurrets()
    {
        for (int i = 0; i < m_turretList.Count; i++)
        {
            m_turretList[i].StartFire();
        }

    }
    public void StopTurrets()
    {
        for (int i = 0; i < m_turretList.Count; i++)
        {
            m_turretList[i].StopFire();
        }
    }
    public void PlayerCollision(Collision collision)
    {
        if (GameMgr.Inst.gameScene.m_battleFSM.IsGameState())
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                m_player.m_audioSource.PlayOneShot(m_player.m_exploseClip);
                m_player.m_explose.gameObject.SetActive(true);
                m_player.m_explose.Play();
                m_player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                StopTurrets();
                StartCoroutine(Wave());
            }
            if (collision.gameObject.CompareTag("Wall"))
            {
                Rigidbody rigidbody = m_player.GetComponent<Rigidbody>();

                rigidbody.velocity = Vector3.zero;

                //float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * m_player.m_playerSpeed;
                //float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * m_player.m_playerSpeed;
                //float newX = Mathf.Clamp(m_player.transform.position.x + x, -8.5f, 8.5f);
                //float newZ = Mathf.Clamp(m_player.transform.position.x + z, -8.5f, 8.5f);
                //Vector3 moveV = new Vector3(newX, m_player.transform.position.y, newZ);
                //m_player.transform.position = moveV;
            }
        }
    }
    IEnumerator Wave()
    {
        GameMgr.Inst.gameScene.m_battleFSM.SetWaveState();
        yield return new WaitForSeconds(3f);
        GameMgr.Inst.gameScene.m_battleFSM.SetResultState();
    }
    private void Update()
    {
        m_BG.transform.Rotate(new Vector3(0, 2, 0) * Time.deltaTime);
        
    }
}
