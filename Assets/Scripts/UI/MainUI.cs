using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour {

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
