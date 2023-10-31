using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : MonoBehaviour
{
    public ParticleSystem m_explose;
    public float playerSpeed = 1.0f;
    public AudioSource m_explodeSound;
    
    // Update is called once per frame
    void Update()
    {
        MoveInput();
    }
    void MoveInput()
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
            m_explodeSound.Play();
            m_explose.gameObject.SetActive(true);
            m_explose.Play();
        }
    }
}
