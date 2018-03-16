using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachDestroyer : MonoBehaviour
{

    void Start()
    {

    }

    void FixedUpdate()
    {
        Vector3 beachPosition = transform.position;
        beachPosition.y -= Camera.main.GetComponent<SideScrolling>().ScrollingSpeed;
        transform.position = beachPosition;
        if (transform.position.y < Camera.main.GetComponent<SideScrolling>().BottomBorder)
        {
            Destroy(gameObject);
        }
    }
}
