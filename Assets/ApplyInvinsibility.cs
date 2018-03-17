using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyInvinsibility : MonoBehaviour {

    [SerializeField]
    float duration;

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.y -= Camera.main.GetComponent<SideScrolling>().ScrollingSpeed * Time.deltaTime;
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Invinsibility>().taken = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Invinsibility>().hasSpawned = false;
            StartCoroutine(InvinsibilityDuration());
        }
    }

    IEnumerator InvinsibilityDuration()
    {
        yield return new WaitForSeconds(duration);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Invinsibility>().taken = false;
    }

}
