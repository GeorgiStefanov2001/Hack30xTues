using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public bool canStart;

    [SerializeField]
    Text startText;

	void Start () {
        canStart = false;
        StartCoroutine(wait3Secs()); 
    }
	
	void Update () {
		
	}

    IEnumerator wait3Secs()
    {
        startText.text = "3";
        yield return new WaitForSeconds(1f);
        startText.text = "2";
        yield return new WaitForSeconds(1f);
        startText.text = "1";
        yield return new WaitForSeconds(1f);
        startText.text = "START";
        canStart = true;
        yield return new WaitForSeconds(1f);
        startText.text = " ";
    }
}
