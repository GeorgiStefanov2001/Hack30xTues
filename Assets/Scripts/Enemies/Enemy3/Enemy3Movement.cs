using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Movement : MonoBehaviour {

    bool canShoot = false;
    bool shooting = false;
    bool hasReachedTop = false;
    [SerializeField]
    float paddingY,paddingX;
    string whereToGo;
    [SerializeField]
    GameObject bullet;

    void Start () {
        whereToGo = Random.Range(1, 3) == 1 ? "left" : "right";
    }
	
	void FixedUpdate () {
        Move();
        if(hasReachedTop && !shooting)
        {
            canShoot = true;
            shooting = true;
        }
        Shoot();
    }

    void Shoot()
    {
        if (canShoot)
        {
            GameObject bull = Instantiate(bullet);
            bull.transform.position = transform.position;
            canShoot = false;
            StartCoroutine(waitForCooldown());
        }
    }

    void Move()
    {
        if (transform.position.y >= paddingY)
        {
            hasReachedTop = true;
            if (whereToGo == "left")
            {
                var pos = transform.position;
                pos.x -= GetComponent<EnemyClass>().Speed * Time.deltaTime;
                if (pos.x <= -paddingX)
                {
                    whereToGo = "right";
                }
                transform.position = pos;
            }

            if (whereToGo == "right")
            {
                var pos = transform.position;
                pos.x += GetComponent<EnemyClass>().Speed * Time.deltaTime;
                if (pos.x >= paddingX)
                {
                    whereToGo = "left";
                }
                transform.position = pos;
            }
        }
        else
        {
            var pos = transform.position;
            pos.y += GetComponent<EnemyClass>().Speed * Time.deltaTime;
            transform.position = pos;
        }
    }

    IEnumerator waitForCooldown()
    {
        yield return new WaitForSeconds(GetComponent<EnemyClass>().shootingCooldown);
        canShoot = true;
    }
}
