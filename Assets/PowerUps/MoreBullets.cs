using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreBullets : MonoBehaviour {

    public int chance;
    [SerializeField]
    GameObject powerIcon;
    public bool taken = false;

    void Update()
    {
        if (taken)
        {
            if (GetComponent<PlayerShooting>().NumberOfBullets >= 5)
            {
                GetComponent<PlayerShooting>().NumberOfBullets = 5;
            }
        }
    }

	public void PowerUp(GameObject killed)
    {
        if(Random.value*100<=chance* killed.GetComponent<EnemyClass>().chanceMultiplier)
        {
            GameObject icon = Instantiate(powerIcon);
            icon.transform.position = killed.transform.position;
        }
    }
}
