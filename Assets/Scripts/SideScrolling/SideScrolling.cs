using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    public float BottomBorder, ScrollingSpeed;

    [SerializeField]
    List<GameObject> waterTiles = new List<GameObject>();
    Vector3 startPosition = new Vector3();

    void Start()
    {
        startPosition = waterTiles[1].transform.position;
    }

    void FixedUpdate()
    {
        Sidescrolling();
    }

    void Sidescrolling()
    {
        for (int i = 1; i < waterTiles.Count; i++)
        {
            Vector3 position = waterTiles[i].transform.position;
            position.y -= ScrollingSpeed * Time.deltaTime;
            if (waterTiles[i].transform.position.y + waterTiles[i].GetComponent<SpriteRenderer>().size.y / 2 < BottomBorder)
            {
                position = startPosition;
            }

            waterTiles[i].transform.position = position;
        }
    }
}
