using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreBullets : MonoBehaviour {

    public int duration;
    public int chance;

	public void PowerUp(GameObject killed)
    {
        if(Random.value*100<=chance* killed.GetComponent<EnemyClass>().chanceMultiplier)
        {
            GetComponent<PlayerShooting>().NumberOfBullets = 2;
        }
    }
}
