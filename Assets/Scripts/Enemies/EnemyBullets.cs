using System.Collections;
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
        Vector2 pos = transform.position;
        pos.y -= bulletSpeed * Time.deltaTime;
        transform.position = pos;
    }

    public void Rotate()
    {
        var direction = transform.position - playerPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}
