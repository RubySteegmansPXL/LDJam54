using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] enemyPrefabs;
    public float timeBetweenWaves = 5f;
    public int initialNumberOfEnemies = 5;
    public float timeBetweenSpawns = 1f;
    public float spawnIncreaseFactor = 1.5f;
    public float spawnTimeDecreaseFactor = 0.9f;
    public int currentWave = 1;

    private int enemiesToSpawn;
    private float currentSpawnTime;
    private bool isWaveInProgress = false;

    private void Start()
    {
        enemiesToSpawn = initialNumberOfEnemies;
        currentSpawnTime = timeBetweenSpawns;
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        isWaveInProgress = true;
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(currentSpawnTime);
        }
        isWaveInProgress = false;
    }

    private void Update()
    {
        if (!isWaveInProgress && FindObjectsOfType<Enemy>().Length == 0)
        {
            currentWave++;
            enemiesToSpawn = Mathf.RoundToInt(enemiesToSpawn * spawnIncreaseFactor);
            currentSpawnTime *= spawnTimeDecreaseFactor;
            StartCoroutine(SpawnWave());
            EventManager.instance.WaveCompleted(1);
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Enemy e = Instantiate(enemyPrefab);
        e.transform.position = transform.position;
    }
}
