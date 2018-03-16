using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeForSoldiers : MonoBehaviour
{
    public Text time;
    float timeEarned;

    void Start()
    {
        timeEarned = 0;
    }

    void FixedUpdate()
    {
        timeEarned = Time.timeSinceLevelLoad;
        time.text = timeEarned.ToString("0.000");
    }
}
