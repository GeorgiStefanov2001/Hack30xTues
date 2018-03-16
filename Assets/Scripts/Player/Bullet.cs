using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float MaxScreen;
    public float shootingSpeed;


    void Start()
    {

    }

    void Update()
    {
        Vector3 position = transform.position;
        position.y += shootingSpeed * Time.deltaTime;
        transform.position = position;
        if (transform.position.y > MaxScreen)
        {
            Destroy(gameObject);
        }
    }
}
