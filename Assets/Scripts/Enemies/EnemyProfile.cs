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
}
