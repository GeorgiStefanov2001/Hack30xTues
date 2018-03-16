using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool isDead;

    void Start()
    {
        isDead = false;
    }


    void FixedUpdate()
    {
        if (!isDead)
        {
            Move();
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    void Move()
    {
        if (Input.GetMouseButton(0) && Camera.main.GetComponent<GameController>().canStart)
        {
            transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            isDead = true;
        }
    }
}
