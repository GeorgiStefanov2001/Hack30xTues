using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemies : MonoBehaviour {

    [SerializeField]
    GameObject enemy1;

    bool canSpawnEnemy1 = true;//for now

    void Start () {
    }

    void Update() {
        SpawnEnemy1();
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
                StartCoroutine(waitForRespawn(enemy1.GetComponent<EnemyClass>().respawnTime));
            }
            else
            {
                canSpawnEnemy1 = false;
                StartCoroutine(waitForRespawn(enemy1.GetComponent<EnemyClass>().respawnTime));
            }
        }
    }

    IEnumerator waitForRespawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canSpawnEnemy1 = true;
    }
}
