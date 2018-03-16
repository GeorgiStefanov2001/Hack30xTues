using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeForSoldiers : MonoBehaviour
{
    public Text time;
    public float timeEarned;
    public float TimeMultiplier;

    void Start()
    {
        timeEarned = 0;
    }

    void FixedUpdate()
    {
        if (Camera.main.GetComponent<GameController>().canStart)
        {
            timeEarned = Time.timeSinceLevelLoad - 3f;
            time.text = timeEarned.ToString("0.00");
        }
    }
}
