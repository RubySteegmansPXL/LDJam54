using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] enemyPrefabs;
    public int initialNumberOfEnemies = 5;
    public int initialNumberOfGroups = 7;
    public int currentWave = 1;

    private int enemiesToSpawn;
    private int groupsToSpawn;
    private float minSpawnTime = 1f;
    private float maxSpawnTime = 3f;
    private float minGroupTime = 5f;
    private float maxGroupTime = 15f;
    private bool isWaveInProgress = false;

    private void Start()
    {
        enemiesToSpawn = initialNumberOfEnemies;
        groupsToSpawn = initialNumberOfGroups;
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        isWaveInProgress = true;
        if (currentWave > 1) { yield return new WaitForSeconds(20f); }
        for (int i = 0; i < groupsToSpawn; i++)
        {
            StartCoroutine(SpawnGroup());
            yield return new WaitForSeconds(Mathf.RoundToInt(Random.Range(minGroupTime, maxGroupTime)));
        }
        isWaveInProgress = false;
    }

    private IEnumerator SpawnGroup()
    {
        for (int i = 0; i < Random.Range(1, enemiesToSpawn); i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Mathf.RoundToInt(Random.Range(minSpawnTime, maxSpawnTime)));
        }
    }


    private void Update()
    {
        if (!isWaveInProgress && FindObjectsOfType<Enemy>().Length == 0)
        {
            currentWave++;
            groupsToSpawn *= Mathf.RoundToInt(Random.Range(1.2f, 1.7f));
            enemiesToSpawn *= Mathf.RoundToInt(Random.Range(1.2f, 1.7f));
            StartCoroutine(SpawnWave());
            EventManager.instance.WaveCompleted();
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Enemy e = Instantiate(enemyPrefab);
        e.transform.position = transform.position;
        e.transform.rotation = transform.rotation;
    }
}
