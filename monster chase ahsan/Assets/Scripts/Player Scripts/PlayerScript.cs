using NUnit.Framework.Constraints;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerScript : MonoBehaviour
{
    // When i am on the ground then only i can jump
    // If you're in air you'll not be able to jump 
    // Collision means two objects re touching each other
    public float moveSpeed;
    public float jumpForce;
    public bool isGrounded;
    public Animator animator;
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 6;
        jumpForce = 6;
        isGrounded = true;
        animator = GetComponent<Animator>(); 
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        JumpPlayer();
    }           

    void MovePlayer()
    {
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            spriteRenderer.flipX = true;
            this.transform.Translate(-moveSpeed * Time.deltaTime,0,0);
            animator.SetBool("Walk",true);
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            spriteRenderer.flipX = false;   
            this.transform.Translate(moveSpeed * Time.deltaTime,0,0);
            animator.SetBool("Walk",true);
        }
        else
        {
            animator.SetBool("Walk",false);
        }
    }

    void JumpPlayer()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded == true)// space AND ground
        {
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, jumpForce);
            animator.SetBool("Jump",true);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))//whether player is touching any object tht has tag ground    
        {
            isGrounded = true;
            animator.SetBool("Jump",false);
        }
    }
}
