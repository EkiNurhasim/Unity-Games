using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoints;

    public float timeBetweenSpawn;
    float nextSpawnTime;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            Instantiate(enemy.gameObject, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            nextSpawnTime = Time.time + timeBetweenSpawn;
        }
    }
}
