using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour

{
    public float moveSpeed;
    public GameObject bulletObject;
    public SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ShootBullet());
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        this.transform.Translate(moveSpeed * Time.deltaTime,0,0);
    }

    IEnumerator ShootBullet()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1,6));
            if (spriteRenderer.flipX == true)
            {
                var bullet = Instantiate(bulletObject);
                bullet.transform.position = new Vector3(this.GetComponent<BoxCollider2D>().bounds.center.x + this.GetComponent<BoxCollider2D>().bounds.extents.x-1.5f ,this.GetComponent<BoxCollider2D>().bounds.center.y,1); 
                bullet.GetComponent<EnemyBulletScript>().moveSpeed = -6;
            }
            else
            {
                var bullet = Instantiate(bulletObject);
                bullet.transform.position = new Vector3(this.GetComponent<BoxCollider2D>().bounds.center.x + this.GetComponent<BoxCollider2D>().bounds.extents.x+0.5f ,this.GetComponent<BoxCollider2D>().bounds.center.y,1);
                bullet.GetComponent<EnemyBulletScript>().moveSpeed = 6;
            }
        }
        
        
    }
}