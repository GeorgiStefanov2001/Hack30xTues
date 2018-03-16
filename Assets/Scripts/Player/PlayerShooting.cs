using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField]
    float ShootingCooldown;

    [SerializeField]
    GameObject bullet;

    public bool canShoot = true;

    void Start()
    {
    }

    void FixedUpdate()
    {
        if (canShoot && Camera.main.GetComponent<GameController>().canStart)
        {
            GameObject bull = Instantiate(bullet);
            Vector3 offset = new Vector3(0f,GetComponent<SpriteRenderer>().size.y/2,0f);
            bull.transform.position = transform.position + offset;
            canShoot = false;
            StartCoroutine(ShootDowntime());
        }
    }

    IEnumerator ShootDowntime()
    {
        yield return new WaitForSeconds(ShootingCooldown);
        canShoot = true;
    }
}
