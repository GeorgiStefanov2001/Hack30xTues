﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
