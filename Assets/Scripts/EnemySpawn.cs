using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyObject;
    private GameObject[] spawnPoints;
    public float numberOfEnemies, maxEnemies;

    public static EnemySpawn Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        InvokeRepeating("SpawnEnemies", 0.5f, 2f);
    }

    // Update is called once per frame

    void SpawnEnemies()
    {
        while (numberOfEnemies < maxEnemies) {
            // Randomly choose a spawn location
            int loc = Random.Range(0, spawnPoints.Length);

            // Spawn a new enemy
            Instantiate(enemyObject, spawnPoints[loc].transform.position, spawnPoints[loc].transform.rotation);

            // Increase count
            numberOfEnemies++;
            
            print($"Created {spawnPoints[loc].transform.position} at {spawnPoints[loc].transform.rotation}!");
            print(spawnPoints.Length);
        }

    }






}
