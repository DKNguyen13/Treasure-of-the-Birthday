using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed,strength;
    [SerializeField] private Transform groundCheckCollider;

    [SerializeField]LayerMask groundLayer;
    private float horizontalInput;

    private Rigidbody2D rb;
    private Animator animator;

    
    [SerializeField] private bool isGrounded = false;

    const float groundCheckRadius = 0.2f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Run();
        Jump();
        animator.SetBool("Run",horizontalInput!=0);
        animator.SetBool("Ground",isGrounded);
    }

    void FixedUpdate()
    {
        GroundCheck();    
    }
    //Run
    private void Run()
    {
        rb.velocity = new Vector2 (horizontalInput * speed, rb.velocity.y);
        if(horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
    }

    //Jump
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x/2 ,strength);
            //rb.AddForce(new Vector2(0f, strength), ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            isGrounded = false;
        }
    }

    private void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius,groundLayer); 
        if(colliders.Length > 0)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, -5f); // Đặt vận tốc dọc để nhân vật trượt xuống
            //transform.position = new Vector3(transform.localScale.x * 1f + transform.position.x, transform.position.y, transform.position.z);
            
        }
    }
}
