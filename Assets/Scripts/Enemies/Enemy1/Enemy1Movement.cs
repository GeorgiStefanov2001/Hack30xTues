using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour {

    [SerializeField]
    GameObject bullet;

    bool canShoot = true; // for now

    Vector3 playerPos;
    void Start() {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Rotate();
    }

    void FixedUpdate() {
        Move();
        DestroyWhenOffScreen();
        var dist = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);

        if (dist <= GetComponent<EnemyClass>().aggroRange && canShoot)
        { 
            GameObject bull = Instantiate(bullet);
            bull.transform.position = transform.position;
            canShoot = false;
            StartCoroutine(waitForCooldown());
        }
    }

    void Move()
    {
        transform.position += transform.up * GetComponent<EnemyClass>().Speed * Time.deltaTime;
    }

    void DestroyWhenOffScreen()
    {
        if (transform.position.y < -GetComponent<EnemyClass>().SpawnPointY || transform.position.x < -3.5f || transform.position.x > 3.5f)
        {
            Destroy(gameObject);
        }
    }

    public void Rotate()
    {
        var direction = transform.position - playerPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle+90f);
    }

    IEnumerator waitForCooldown()
    {
        yield return new WaitForSeconds(GetComponent<EnemyClass>().shootingCooldown);
        canShoot = true;
    }
}
