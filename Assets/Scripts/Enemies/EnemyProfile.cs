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
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpeedBonus>().SpeedUp(gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<MoreBullets>().PowerUp(gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<ShieldBonus>().PowerUp(gameObject);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy" && coll.gameObject != gameObject)
        {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        }
    }

}
