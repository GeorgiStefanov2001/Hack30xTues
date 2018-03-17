using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float accelerometerSpeed;
    public bool isDead;
    public bool hasShield;

    [SerializeField]
    float PaddingY, PaddingX;

    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("Controls"));
        isDead = false;
        hasShield = false;
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
        if (Camera.main.GetComponent<GameController>().canStart) {
            if (PlayerPrefs.GetString("Controls") == "Finger movement")
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.touches[0];

                    transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(touch.position), speed * Time.deltaTime);
                }
            }
            else if (PlayerPrefs.GetString("Controls") == "Accelerometer")
            {
                Vector3 dir = Vector3.zero;
                dir.x = Input.acceleration.x;
                dir.y = Input.acceleration.y;

                transform.position += (dir * Time.deltaTime * accelerometerSpeed);
            }

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
            if (hasShield)
            {
                hasShield = false;
            }
            else
            {
                isDead = true;
            }
        }
    }
}
