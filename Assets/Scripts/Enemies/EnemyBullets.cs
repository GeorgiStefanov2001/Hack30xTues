﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour {

    Vector3 playerPos;

    [SerializeField]
    float bulletSpeed;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Rotate();
    }

    void FixedUpdate () {
        Move();
    }

    void Move()
    {
        transform.position += transform.up * bulletSpeed * Time.deltaTime;

        if (transform.position.y < -5.5f || transform.position.y>5.5f || transform.position.x < -3.5f || transform.position.x > 3.5f)
        {
            Destroy(gameObject);
        }
    }

    public void Rotate()
    {
        var direction = transform.position - playerPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (!coll.gameObject.GetComponent<PlayerMovement>().hasInvincibility){
                if (coll.gameObject.GetComponent<PlayerMovement>().hasShield)
                {
                    coll.gameObject.GetComponent<ShieldBonus>().hasSpawned = false;
                    coll.gameObject.GetComponent<PlayerMovement>().hasShield = false;
                }
                else
                {
                    coll.gameObject.GetComponent<PlayerMovement>().isDead = true;
                }
            }
            Destroy(gameObject);
        }
    }
}
