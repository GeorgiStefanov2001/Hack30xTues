using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeForSoldiers : MonoBehaviour
{

    public Text time;

    void Start()
    {

    }

    void FixedUpdate()
    {
        float timeEarned = Time.realtimeSinceStartup;
        time.text = timeEarned.ToString(".000");
    }
}
