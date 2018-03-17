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
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpeedBonus>().Spawn(gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<MoreBullets>().PowerUp(gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<ShieldBonus>().Spawn(gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Invinsibility>().Spawn(gameObject);
            Camera.main.GetComponent<GameController>().Explode(gameObject.transform);
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
