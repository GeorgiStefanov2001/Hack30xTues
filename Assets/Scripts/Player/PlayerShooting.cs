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
                case 2: SpawnTwoBullets(1,8); break;
                case 3: SpawnThreeBullets(1, 8);break;
                case 4: SpawnFourBullets(2,8); break;
                case 5: SpawnFiveBullets(2, 8);break;
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

    void SpawnTwoBullets(int multipl,int div)
    {
        for(int i = 0; i < 2; i++)
        {
            GameObject bull = Instantiate(bullet);
            Vector3 offset = new Vector3(GetComponent<SpriteRenderer>().size.x/div*multipl, GetComponent<SpriteRenderer>().size.y / 2, 0f);
            bull.transform.position = transform.position + offset;
            canShoot = false;
            multipl *= -1;
            StartCoroutine(ShootDowntime());
        }
    }

    void SpawnThreeBullets(int multipl, int div)
    {
        SpawnOneBullet();
        SpawnTwoBullets(multipl, div);
    }

    void SpawnFourBullets(int multipl,int div)
    {
        for(int i = 0; i < 2; i++)
        {
            SpawnTwoBullets(multipl,div);
            div /= 2;
        }
    }

    void SpawnFiveBullets(int multipl,int div)
    {
        SpawnFourBullets(multipl, div);
        SpawnOneBullet();
    }


    IEnumerator ShootDowntime()
    {
        yield return new WaitForSeconds(ShootingCooldown);
        canShoot = true;
    }
}
