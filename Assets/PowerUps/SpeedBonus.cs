using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : MonoBehaviour {

    [SerializeField]
    float speedCoolDown, chance;
    [SerializeField]
    bool hasMoreSpeed;//for testing
    

	void Start () {
        hasMoreSpeed = false;
	}

    public void SpeedUp()
    {
        if (!hasMoreSpeed)
        {
            GetComponent<PlayerMovement>().speed += 10;
            GetComponent<PlayerMovement>().accelerometerSpeed += 10;

            StartCoroutine(SpeedBonusCoolDown(speedCoolDown));
            hasMoreSpeed = true;
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
