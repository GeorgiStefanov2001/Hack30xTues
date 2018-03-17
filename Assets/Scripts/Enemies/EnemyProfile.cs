using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProfile : MonoBehaviour {

    public int hp;
	void Start () {
        hp = GetComponent<EnemyClass>().Health;
	}
	
	void Update () {
        CheckHealth();
	}

    void CheckHealth()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy" && coll.gameObject != gameObject)
        {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }

}
