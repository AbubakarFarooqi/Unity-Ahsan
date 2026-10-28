using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public string[] positions = {"Left","Right"};
    public Vector3 leftPos;
    public Vector3 rightPos;
    public List<GameObject> enemies;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1,3));
            string position = positions[Random.Range(0,2)];
            var enemy = enemies[Random.Range(0,3)];
            var spawnedEnemy = Instantiate(enemy);

            if (position == "Left")
            {
                spawnedEnemy.transform.position = leftPos;
                spawnedEnemy.GetComponent<EnemyScript>().moveSpeed = Random.Range(3,10);
                spawnedEnemy.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (position == "Right")
            {
                spawnedEnemy.transform.position = rightPos;
                spawnedEnemy.GetComponent<EnemyScript>().moveSpeed = Random.Range(3,10) * -1;
                spawnedEnemy.GetComponent<SpriteRenderer>().flipX = true;


            }
        }
    }
}
