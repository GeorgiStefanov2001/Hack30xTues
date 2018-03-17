using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : MonoBehaviour {

    [SerializeField]
    float speedCoolDown, chance;
    [SerializeField]
    bool hasMoreSpeed;
    [SerializeField]
    GameObject SpeedIcon;
    public bool taken;
    

	void Start () {
        hasMoreSpeed = false;
        taken = false;
	}

    public void SpeedUp(GameObject killed)
    {
        if (!hasMoreSpeed && Random.value*100<=chance*killed.GetComponent<EnemyClass>().chanceMultiplier)
        {
            GameObject icon = Instantiate(SpeedIcon);
            icon.transform.position = killed.transform.position;
            if (taken)
            {
                GetComponent<PlayerMovement>().speed += 10;
                GetComponent<PlayerMovement>().accelerometerSpeed += 10;
                StartCoroutine(SpeedBonusCoolDown(speedCoolDown));
                hasMoreSpeed = true;
                taken = false;
            }
        }
    }

    IEnumerator SpeedBonusCoolDown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        hasMoreSpeed = false;
        GetComponent<PlayerMovement>().speed -= 10;
        GetComponent<PlayerMovement>().accelerometerSpeed -= 10;

    }
}
