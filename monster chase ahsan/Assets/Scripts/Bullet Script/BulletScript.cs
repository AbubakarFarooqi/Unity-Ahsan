using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 6;
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
