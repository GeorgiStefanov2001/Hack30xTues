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
    public bool hasSpawned;
    [SerializeField]
    GameObject bullet;
    

	void Start () {
        hasMoreSpeed = false;
        hasSpawned = false;
        taken = false;
	}

    void Update()
    {
        if (taken)
        {
            GetComponent<PlayerMovement>().speed += 10;
            GetComponent<PlayerMovement>().accelerometerSpeed += 10;
            bullet.GetComponent<Bullet>().shootingSpeed += 10;
            StartCoroutine(SpeedBonusCoolDown(speedCoolDown));
            hasMoreSpeed = true;
            taken = false;
            hasSpawned = false;
        }
    }

    public void Spawn(GameObject killed)
    {
        if (!hasMoreSpeed && Random.value * 100 <= chance * killed.GetComponent<EnemyClass>().chanceMultiplier && !hasSpawned)
        {
            hasSpawned = true;
            GameObject icon = Instantiate(SpeedIcon);
            icon.transform.position = killed.transform.position;
        }
    }

    IEnumerator SpeedBonusCoolDown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        GetComponent<PlayerMovement>().speed -= 10;
        GetComponent<PlayerMovement>().accelerometerSpeed -= 10;
        bullet.GetComponent<Bullet>().shootingSpeed -= 10;
        hasMoreSpeed = false;

    }
}
