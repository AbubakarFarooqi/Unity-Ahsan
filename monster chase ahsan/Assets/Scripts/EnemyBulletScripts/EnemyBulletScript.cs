using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float moveSpeed;  
    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Collider2D bulletCollider = GetComponent<Collider2D>();

        foreach (GameObject enemy in enemies)
        {
            Collider2D enemyCollider = enemy.GetComponent<Collider2D>();

            if (enemyCollider != null && bulletCollider != null)
            {
                Physics2D.IgnoreCollision(bulletCollider, enemyCollider);
            }
        }
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
}
