using UnityEngine;

public class Camerascript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform playerTransform;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = this.transform.position;
        camPos.x = playerTransform.position.x;
        this.transform.position = camPos;
    }
}
