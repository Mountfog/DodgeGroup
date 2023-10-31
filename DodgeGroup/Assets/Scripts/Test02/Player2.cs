using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float playerSpeed = 5f;
    public ParticleSystem m_explosives;
    public AudioSource m_audioSource = null;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        float inputx = x * playerSpeed * Time.deltaTime;
        float inputz = z * playerSpeed * Time.deltaTime;
        transform.Translate(inputx, 0, inputz);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            m_explosives.gameObject.SetActive(true);
            m_explosives.Play();
            m_audioSource.Play();
        }
    }
}
