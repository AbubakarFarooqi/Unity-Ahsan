using System;
using NUnit.Framework.Constraints;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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
    [SerializeField]
    public int lives;
    public TMP_Text lives_tmp;
    public TMP_Text scores_tmp;
    public GameObject bulletObject;
    public bool isBulletOnScreen;
    public int scores;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 6;
        jumpForce = 6;
        isGrounded = true;
        isBulletOnScreen = false;
        animator = GetComponent<Animator>(); 
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lives_tmp.SetText("Lives: {0}", lives);
        scores = 0;
        scores_tmp.SetText("Scores: {0}", scores);

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        JumpPlayer();
        ShootBullet();  
        if (lives == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }           

    void MovePlayer()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            spriteRenderer.flipX = true;
            this.transform.Translate(-moveSpeed * Time.deltaTime,0,0);
            animator.SetBool("Walk",true);
        }
        else if (Keyboard.current.dKey.isPressed)
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

    void ShootBullet()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && isBulletOnScreen == false)
        {
            if (spriteRenderer.flipX == true)
            {
               var bullet = Instantiate(bulletObject);
                bullet.transform.position = new Vector3(this.GetComponent<BoxCollider2D>().bounds.center.x + this.GetComponent<BoxCollider2D>().bounds.extents.x-1.5f ,this.GetComponent<BoxCollider2D>().bounds.center.y,1); 
                bullet.GetComponent<BulletScript>().moveSpeed = -6;
                bullet.GetComponent<BulletScript>().BulletHit += BulletHitEnemy;
                bullet.GetComponent<BulletScript>().EnemyHit += IncreaseScore;

            }
            else
            {
                var bullet = Instantiate(bulletObject);
                bullet.transform.position = new Vector3(this.GetComponent<BoxCollider2D>().bounds.center.x + this.GetComponent<BoxCollider2D>().bounds.extents.x+0.5f ,this.GetComponent<BoxCollider2D>().bounds.center.y,1);
                bullet.GetComponent<BulletScript>().moveSpeed = 6;
                bullet.GetComponent<BulletScript>().BulletHit += BulletHitEnemy;
                bullet.GetComponent<BulletScript>().EnemyHit += IncreaseScore;

            }
            isBulletOnScreen = true;
            
        }
    }
    void BulletHitEnemy()
    {
        isBulletOnScreen = false;
    }

    void IncreaseScore()
    {
        scores++;
        scores_tmp.SetText("Scores: {0}", scores);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))//whether player is touching any object tht has tag ground    
        {
            isGrounded = true;
            animator.SetBool("Jump",false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            lives = lives-1;
            Destroy(other.gameObject);
            lives_tmp.SetText("Lives: {0}", lives);
        }
    }
}
