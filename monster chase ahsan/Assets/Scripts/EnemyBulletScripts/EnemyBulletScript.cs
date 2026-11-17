using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float moveSpeed;  
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
}
