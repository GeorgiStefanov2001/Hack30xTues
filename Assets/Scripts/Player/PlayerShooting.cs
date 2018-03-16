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
            bull.transform.position = transform.position + new Vector3(0.0f, GetComponent<BoxCollider2D>().size.y / 2 + bull.GetComponent<BoxCollider2D>().size.y / 2, 0.0f);
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
