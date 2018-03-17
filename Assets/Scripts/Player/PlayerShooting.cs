using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField]
    float ShootingCooldown;

    [SerializeField]
    GameObject bullet;

    public int NumberOfBullets;

    public bool canShoot = true;

    void Start()
    {
        NumberOfBullets = 1;
    }

    void FixedUpdate()
    {
        if (canShoot && Camera.main.GetComponent<GameController>().canStart)
        {

            switch (NumberOfBullets)
            {
                case 1: SpawnOneBullet();break;
                case 2: SpawnPoweredBullets(2);
                    StartCoroutine(DurationOfMoreBullets());
                    break;
            }
        }
    }

    void SpawnOneBullet()
    {
        GameObject bull = Instantiate(bullet);
        Vector3 offset = new Vector3(0f, GetComponent<SpriteRenderer>().size.y / 2, 0f);
        bull.transform.position = transform.position + offset;
        canShoot = false;
        StartCoroutine(ShootDowntime());
    }

    void SpawnPoweredBullets(int divX)
    {
        var divY = divX;
        for(int i = 0; i < 2; i++,divX*=2)
        {
            GameObject bull = Instantiate(bullet);
            Vector3 offset = new Vector3(-GetComponent<SpriteRenderer>().size.x / divX, GetComponent<SpriteRenderer>().size.y / divY, 0f);
            bull.transform.position = transform.position + offset;
        }
        divX = divY;
        for (int i = 0; i < 2; i++, divX *= 2)
        {
            GameObject bull = Instantiate(bullet);
            Vector3 offset = new Vector3(GetComponent<SpriteRenderer>().size.x / divX, GetComponent<SpriteRenderer>().size.y / divY, 0f);
            bull.transform.position = transform.position + offset;
        }

        canShoot = false;
        StartCoroutine(ShootDowntime());
    }

    IEnumerator DurationOfMoreBullets()
    {
        yield return new WaitForSeconds(GetComponent<MoreBullets>().duration);
        NumberOfBullets = 1;
    }

    IEnumerator ShootDowntime()
    {
        yield return new WaitForSeconds(ShootingCooldown);
        canShoot = true;
    }
}
