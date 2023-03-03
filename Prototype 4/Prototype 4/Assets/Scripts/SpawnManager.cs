using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject[] powerupPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(waveNumber);
        int randomPowerup = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(), powerupPrefabs[randomPowerup].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyScript>().Length;
        if (enemyCount == 0) {
            waveNumber++;
            SpawnEnemies(waveNumber);
            int randomPowerup = Random.Range(0, powerupPrefabs.Length);
            Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(), powerupPrefabs[randomPowerup].transform.rotation);
        }
    }

    private Vector3 GenerateSpawnLocation() {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPosition = new Vector3(spawnPositionX, 23, spawnPositionZ);
        return randomPosition;
    }

    private Vector3 GenerateSpawnLocationPU() {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPosition = new Vector3(spawnPositionX, -0.5f, spawnPositionZ);
        return randomPosition;
    }

    void SpawnEnemies(int enemiesToSpawn) {
        for (int i = 0; i < enemiesToSpawn; i++) {
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomEnemy], GenerateSpawnLocation(), enemyPrefabs[randomEnemy].transform.rotation);
        }
    }
}
