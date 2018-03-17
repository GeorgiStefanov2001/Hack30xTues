using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBonus : MonoBehaviour {
    [SerializeField]
    float chance;
    public bool taken;
    bool hasMoreShields;

    [SerializeField]
    GameObject ShieldIcon;

    void Start()
    {
        taken = false;
        hasMoreShields = false;
    }

    public void PowerUp(GameObject killed)
    {
        if (!hasMoreShields && Random.value * 100 <= chance * killed.GetComponent<EnemyClass>().chanceMultiplier)
        {
            GameObject icon = Instantiate(ShieldIcon);
            icon.transform.position = killed.transform.position;
            if (taken)
            {
                GetComponent<PlayerMovement>().hasShield = true;
            }
        }

    }

}
