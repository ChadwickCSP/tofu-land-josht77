using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 5f;
    float nextSpawn = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // An enemy will spawn every 10 seconds within the range of -8, 8. However, there is an error in the code, so the enemys are spawning behind the tiles
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range (-8f, 8f);
            whereToSpawn = new Vector3 (randX, transform.position.y, -5);
            GameObject newEnemy = Instantiate (enemy);//, whereToSpawn, Quaternion.identity);
            //Instantiate()
            newEnemy.transform.position = whereToSpawn;
        }
    }
}
