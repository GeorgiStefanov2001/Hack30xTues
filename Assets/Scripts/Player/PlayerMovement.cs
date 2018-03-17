using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Time.timeScale = 0;
        }
    }

    void Move()
    {
        if (Input.touchCount>0 && Camera.main.GetComponent<GameController>().canStart)
        {
            Touch touch = Input.touches[0];

            transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(touch.position), speed * Time.deltaTime);
        }
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -PaddingX, PaddingX);
        pos.y = Mathf.Clamp(pos.y, -PaddingY, PaddingY);
        transform.position = pos;
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
