using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyClass {

    public void Enemy1Setup()
    {
        Health = 10;
        Speed = 5f;
        SpawnPointY = 8f;
        respawnTime = 3f;
    }
}
