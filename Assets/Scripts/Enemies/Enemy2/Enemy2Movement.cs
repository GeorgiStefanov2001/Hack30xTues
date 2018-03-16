using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour {

    bool canShoot = true;
    [SerializeField]
    GameObject bullet;

	void Start () {
		
	}
	
	void FixedUpdate () {
        Move();
        Rotate();
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
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = Vector3.MoveTowards(transform.position, target.position, GetComponent<EnemyClass>().Speed * Time.deltaTime);
    }

    void Rotate()
    {
        var direction = transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
    }

    IEnumerator waitForCooldown()
    {
        yield return new WaitForSeconds(GetComponent<EnemyClass>().shootingCooldown);
        canShoot = true;
    }
}
