using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour {

    Vector3 playerPos;
    void Start() {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void Update() {
        Move();
        DestroyWhenOffScreen();
    }

    void Move()
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = Vector2.MoveTowards(transform.position, target.position, GetComponent<Enemy1>().Speed * Time.deltaTime);
    }

    void DestroyWhenOffScreen()
    {
        if (transform.position.y < -GetComponent<Enemy1>().SpawnPointY || transform.position.x < -2.5f || transform.position.x > 2.5f)
        {
            Destroy(gameObject);
        }
    }
}
