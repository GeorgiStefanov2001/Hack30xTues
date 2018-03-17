using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invinsibility : MonoBehaviour {

    public bool hasSpawned, taken;
    public float chance, cooldown;
    [SerializeField]
    GameObject IconPowerUp;

	void Start () {
        hasSpawned = false;
        taken = false;
	}

    void Update()
    {
        if (taken)
        {
            GetComponent<PlayerMovement>().hasInvincibility = true;
            StartCoroutine(InvincibilityCoolDown(cooldown));
            taken = false;
            hasSpawned = false;
        }
    }

    public void Spawn(GameObject killed)
    {
        if(Random.value*100 <= chance * killed.GetComponent<EnemyClass>().chanceMultiplier && !hasSpawned)
        {
            hasSpawned = true;
            GameObject icon = Instantiate(IconPowerUp);
            icon.transform.position = killed.transform.position;
        }
    }

    IEnumerator InvincibilityCoolDown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<PlayerMovement>().hasInvincibility = false;

    }

}
