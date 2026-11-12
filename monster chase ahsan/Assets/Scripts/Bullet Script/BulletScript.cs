using System;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float moveSpeed;
    public event Action BulletHit;
    public event Action EnemyHit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        this.transform.Translate(moveSpeed * Time.deltaTime,0,0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            BulletHit?.Invoke();
            EnemyHit?.Invoke();
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Barrier"))//whether player is touching any object tht has tag ground    
        {
            Destroy(this.gameObject);
            BulletHit?.Invoke();
        }
    }
}
