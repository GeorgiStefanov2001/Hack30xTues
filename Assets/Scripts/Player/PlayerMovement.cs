using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool isDead;

    [SerializeField]
    float PaddingY, PaddingX;

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

            /*if (Input.GetAxis("Fire1") > 0)
            {
                Vector3 movement = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = Vector2.Lerp(transform.position, movement, speed * Time.deltaTime);
            }*/

            if (transform.position.x <= -PaddingX)
            {
                transform.position = new Vector2(-PaddingX, transform.position.y);
            }
            else if (transform.position.x >= PaddingX)
            {
                transform.position = new Vector2(PaddingX, transform.position.y);
            }

            if (transform.position.y <= -PaddingY)
            {
                transform.position = new Vector2(transform.position.x, -PaddingY);
            }
            else if (transform.position.y >= PaddingY)
            {
                transform.position = new Vector2(transform.position.x, PaddingY);
            }
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
