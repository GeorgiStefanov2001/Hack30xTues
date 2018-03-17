using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    [SerializeField]
    GameObject StartMenuPanel;
    [SerializeField]
    GameObject OptionsPanel;
    [SerializeField]
    GameObject ChangeControlsText;

    void Start()
    {
        if (PlayerPrefs.GetString("Controls") != "Finger movemenet" && PlayerPrefs.GetString("Controls") != "Accelerometer")
        {
            PlayerPrefs.SetString("Controls", "Finger movement");
        }
        ChangeControlsText.GetComponent<Text>().text = PlayerPrefs.GetString("Controls");
    }

    public void Start_Game()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        StartMenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void Back()
    {
        StartMenuPanel.SetActive(true);
        OptionsPanel.SetActive(false);
    }

    public void ChangeControls()
    {

        if (PlayerPrefs.GetString("Controls") == "Finger movement")
        {
            PlayerPrefs.SetString("Controls", "Accelerometer");
        }
        else if (PlayerPrefs.GetString("Controls") == "Accelerometer")
        {
            PlayerPrefs.SetString("Controls", "Finger movement");
        }
        ChangeControlsText.GetComponent<Text>().text = PlayerPrefs.GetString("Controls");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
