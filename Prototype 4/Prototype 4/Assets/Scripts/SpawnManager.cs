using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnLocationPU(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyScript>().Length;
        if (enemyCount == 0) {
            waveNumber++;
            SpawnEnemies(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnLocationPU(), powerupPrefab.transform.rotation);
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
            Instantiate(enemyPrefab, GenerateSpawnLocation(), enemyPrefab.transform.rotation);
        }
    }
}
