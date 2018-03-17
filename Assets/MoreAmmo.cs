using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreAmmo : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<PlayerShooting>().NumberOfBullets = 2;
            Destroy(gameObject);
        }
    }
}
