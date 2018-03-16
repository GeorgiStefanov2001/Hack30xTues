﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemies : MonoBehaviour {

    [SerializeField]
    GameObject enemy1;
    [SerializeField]
    GameObject enemy2;

    public bool canSpawnEnemy1 = true;//for now
    public bool canSpawnEnemy2 = true;

    void Start () {
    }

    void Update() {
        SpawnEnemy1();
        SpawnEnemy2();
    }

    void SpawnEnemy(float Xpos, float Ypos,GameObject enemyType)
    {
        GameObject enemy = Instantiate(enemyType);
        enemy.transform.position = new Vector2(Xpos, Ypos);
    }

    void SpawnEnemy1()
    {
        if (canSpawnEnemy1)
        {
            if (Random.value <= 0.5f)
            {
                for (int i = 0; i < 3; i++)
                {
                    float rand = Random.Range(-2, 2);
                    SpawnEnemy(rand, enemy1.GetComponent<EnemyClass>().SpawnPointY, enemy1);
                }
                canSpawnEnemy1 = false;
                StartCoroutine(Enemy1waitForRespawn(enemy1.GetComponent<EnemyClass>().respawnTime));
            }
            else
            {
                canSpawnEnemy1 = false;
                StartCoroutine(Enemy1waitForRespawn(enemy1.GetComponent<EnemyClass>().respawnTime));
            }
        }
    }

    void SpawnEnemy2()
    {
        if (canSpawnEnemy2)
        {
            if (Random.value <= 0.35f)
            {
                for (int i = 0; i < 2; i++)
                {
                    float rand = Random.Range(-5, 5);
                    float Xpos;
                    
                    if (Random.Range(1, 3) == 1)
                    {
                        Xpos = enemy2.GetComponent<EnemyClass>().SpawnPointX;
                    }
                    else
                    {
                        Xpos = -enemy2.GetComponent<EnemyClass>().SpawnPointX;
                    }
                    
                    SpawnEnemy(Xpos, rand, enemy2);
                }
                canSpawnEnemy2 = false;
                StartCoroutine(Enemy2waitForRespawn(enemy2.GetComponent<EnemyClass>().respawnTime));
            }
            else
            {
                canSpawnEnemy2 = false;
                StartCoroutine(Enemy2waitForRespawn(enemy2.GetComponent<EnemyClass>().respawnTime));
            }
        }
    }

    IEnumerator Enemy1waitForRespawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canSpawnEnemy1 = true;
    }

    IEnumerator Enemy2waitForRespawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canSpawnEnemy2 = true;
    }
}
