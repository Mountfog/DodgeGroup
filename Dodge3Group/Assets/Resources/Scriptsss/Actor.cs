using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 2f;
    private bool isGround = false;

    private void Start()
    {
        isGround = true;
    }
    // Update is called once per frame
    void Update()
    {
        MoveInput();
    }
    public void MoveInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float inputX = x * moveSpeed * Time.deltaTime;
        float inputZ = z * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(inputX, 0, inputZ));
        if(x != 0 || z != 0)
        {
            animator.SetBool("Walk",true);
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (x < 0)
                sr.flipX = true;
            else
                sr.flipX = false;


        }
        else
        {
            animator.SetBool("Walk",false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("AttackT");
        }
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            if (isGround)
            {
                transform.localPosition += new Vector3(0, 3f, 0);
                animator.SetTrigger("Jump");
                isGround = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            isGround = true;
        }
    }
}
