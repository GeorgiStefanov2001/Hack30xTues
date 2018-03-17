using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public bool canStart;

    [SerializeField]
    Text startText;
    [SerializeField]
    GameObject restartPanel;
    [SerializeField]
    Text soldiersCount;
    [SerializeField]
    GameObject explosion;
    

	void Start () {
        Handheld.Vibrate();
        canStart = false;
        StartCoroutine(wait3Secs());
        restartPanel.SetActive(false);
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
	
	void Update () {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().isDead)
        {
            restartPanel.SetActive(true);
            soldiersCount.text = "Saved " + (GetComponent<TimeForSoldiers>().timeEarned * GetComponent<TimeForSoldiers>().TimeMultiplier).ToString("0");
        }
    }

    IEnumerator wait3Secs()
    {
        startText.text = "3";
        yield return new WaitForSeconds(1f);
        startText.text = "2";
        yield return new WaitForSeconds(1f);
        startText.text = "1";
        yield return new WaitForSeconds(1f);
        startText.text = " START";
        canStart = true;
        yield return new WaitForSeconds(1f);
        startText.text = " ";
    }

    public void Explode(Transform target) {
        explosion.transform.position = target.position;
        explosion.GetComponent <ParticleSystem>().Play();
        
    }
}
