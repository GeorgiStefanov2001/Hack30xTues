using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour {

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float bulletSpeed;

    Vector3 playerPos;
    void Start() {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Rotate();
    }

    void FixedUpdate() {
        Move();
        DestroyWhenOffScreen();
        var dist = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);

        if (dist <= GetComponent<Enemy1>().aggroRange)
        {
            GameObject bull = Instantiate(bullet);
            bull.transform.position = transform.position;
        }
    }

    void Move()
    {
        Vector2 pos = transform.position;
        pos.y -=  GetComponent<Enemy1>().Speed * Time.deltaTime;
        transform.position = pos;
    }

    void DestroyWhenOffScreen()
    {
        if (transform.position.y < -GetComponent<Enemy1>().SpawnPointY || transform.position.x < -2.5f || transform.position.x > 2.5f)
        {
            Destroy(gameObject);
        }
    }

    public void Rotate()
    {
        var direction = transform.position - playerPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}
