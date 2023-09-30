using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] enemyPrefabs;
    public Vector2 spawnRate;        //Spawn 1 vijand per seconde

    private float timeToNextSpawn = 0;


    // Update is called once per frame
    void Update()
    {
        timeToNextSpawn -= Time.deltaTime;
        if (timeToNextSpawn > 0) return;
        Enemy enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Enemy e = GameObject.Instantiate<Enemy>(enemyPrefab);
        e.transform.position = transform.position;
        timeToNextSpawn = Random.Range(spawnRate.x, spawnRate.y);
    }
}
