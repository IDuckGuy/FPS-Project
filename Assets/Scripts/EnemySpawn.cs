/*
    * Basic enemy script which spawns enemies in waves
    * Code by Az Foxxo (https://github.com/AzFoxxo/Scripts)
    * Anarchist License, MIT Licence, GNU GPL v3.0 Licence, or any later version.
*/

using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private ulong enemyMax;
    [SerializeField] private ulong increaseMaxPerWave;
    [SerializeField] public ulong enemyCount = 0;
    private GameObject[] spawnLocations;

    [HideInInspector] public static EnemySpawn Instance;

    // Find all spawn points present in the world
    private void Start() => spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");

    // Spawn
    void Update() => Spawn();


    // Instance
    void Awake() => Instance = this;

    // Spawn method
    private void Spawn()
    {
        // Calculate the number of enemies
        // enemyCount = (ulong)GameObject.FindGameObjectsWithTag("EnemyUwU").Length;

        // If the wave if not over, return
        if (enemyCount != 0) return;

        // Increase max enemies every wave
        enemyMax += increaseMaxPerWave;

        while (enemyCount < enemyMax) {
            // Randomly choose a spawn location
            int loc = Random.Range(0, spawnLocations.Length);

            // Spawn a new enemy
            Instantiate(enemy, spawnLocations[loc].transform.position, spawnLocations[loc].transform.rotation);

            // Increase count
            enemyCount++;
            
            print($"Created {spawnLocations[loc].transform.position} at {spawnLocations[loc].transform.rotation}!");
            print(spawnLocations.Length);
        }
    }
}