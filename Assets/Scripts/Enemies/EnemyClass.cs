using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour {
    public int Health;
    public float Speed;
    public float SpawnPointX;
    public float SpawnPointY;
    public float respawnTime;

    public int HP
    {
        get { return Health; }
        set { Health = value; }
    }

    public float Xpos
    {
        get { return SpawnPointX; }
        set { SpawnPointX = value; }
    }

    public float Ypos
    {
        get { return SpawnPointY; }
        set { SpawnPointY = value; }
    }

    public float Time
    {
        get { return respawnTime; }
        set { respawnTime = value; }
    }

}
