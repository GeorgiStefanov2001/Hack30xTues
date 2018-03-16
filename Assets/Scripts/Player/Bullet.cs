using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float MaxScreen;
    [SerializeField]
    float shootingSpeed;
    [SerializeField]
    int damage;

    void Start()
    {

    }

    void Update()
    {
        Vector3 position = transform.position;
        position.y += shootingSpeed * Time.deltaTime;
        transform.position = position;
        if (transform.position.y > MaxScreen)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyProfile>().hp -= damage;
            Destroy(gameObject);
        }
    }
}
