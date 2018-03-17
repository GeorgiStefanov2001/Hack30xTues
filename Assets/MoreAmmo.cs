using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreAmmo : MonoBehaviour {
    
    void Update()
    {
        var pos = transform.position;
        pos.y -= Camera.main.GetComponent<SideScrolling>().ScrollingSpeed * Time.deltaTime;
        transform.position = pos;
        if (transform.position.y < Camera.main.GetComponent<SideScrolling>().BottomBorder)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>().NumberOfBullets++;
            coll.gameObject.GetComponent<MoreBullets>().taken = true;
            Destroy(gameObject);
        }
    }
}
