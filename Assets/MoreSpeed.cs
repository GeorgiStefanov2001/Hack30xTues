using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreSpeed : MonoBehaviour {

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
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            coll.gameObject.GetComponent<SpeedBonus>().taken = true;
        }
    }
}
