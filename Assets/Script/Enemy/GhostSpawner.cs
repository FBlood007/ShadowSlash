using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefab;
    int randomSpawnPoints;
    int randomEnemy;

    void SpawnEnemy()
    {
        //get random spawn point
        randomSpawnPoints = Random.Range(0, spawnPoints.Length);

        //get random enemy prefab
        randomEnemy = Random.Range(0, enemyPrefab.Length);
        for(int i = 0; i<spawnPoints.Length; i++)
        {
            //Spawning
            Instantiate(enemyPrefab[randomEnemy], spawnPoints[i].position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Is triggered");
        if(collision.tag == "Player")
        {
            SpawnEnemy();
        }
    }

}
