using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    void Start()
    {

    }


    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), speed * Time.deltaTime);
        }
    }
}
