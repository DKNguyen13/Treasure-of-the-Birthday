using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Speed, strength
    [SerializeField] private float speed;
    [SerializeField] private float strength;

    //Move
    private float horizontalInput;

    //
    private Rigidbody2D rb;
    private Animator animator;

    //Check ground 
    private bool ground;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Move();
        /*
        if (Input.GetKeyDown(KeyCode.UpArrow) && ground)
        {
            Jump();
            
        }*/
        //animator.SetBool("Run",horizontalInput!=0);
        animator.SetBool("Ground",ground);
    }

    //Jump
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x / 2, strength);
        //animator.SetTrigger("Jump");
        ground = false;
    }

    //Move
    private void Move()
    {
        rb.velocity = new Vector2 (horizontalInput * speed, 0);
        /*
        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(6.862959f, transform.localScale.y,1);
        }
        else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-6.862959f, transform.localScale.y, 1);
        }
        */
    }

    //OnCollision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Ground"  || collision.gameObject.tag == "Wooden")
        {
            ground = true;
        }
        
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            Debug.Log("Game Over");
        }
    }

}
