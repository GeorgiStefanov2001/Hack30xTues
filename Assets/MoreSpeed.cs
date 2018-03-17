using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreSpeed : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            coll.gameObject.GetComponent<SpeedBonus>().taken = true;
        }
    }
}
