using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBonus : MonoBehaviour {
    [SerializeField]
    float chance;
    public bool taken;
    bool hasMoreShields;
    public bool hasSpawned;

    [SerializeField]
    GameObject ShieldIcon;

    void Start()
    {
        taken = false;
        hasMoreShields = false;
    }

    void Update()
    {
        if (taken)
        {
            GetComponent<PlayerMovement>().hasShield = true;
            taken = false;
        }
    }

    public void Spawn(GameObject killed)
    {
        if (!hasMoreShields && Random.value * 100 <= chance * killed.GetComponent<EnemyClass>().chanceMultiplier && !hasSpawned)
        {
            hasSpawned = true;
            GameObject icon = Instantiate(ShieldIcon);
            icon.transform.position = killed.transform.position;
        }

    }

}
