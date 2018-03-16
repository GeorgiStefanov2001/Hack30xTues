using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour {

    public AudioMixer audioMixer;
    public Slider slider;
    public Text volVal;

    public void Back() {
        SceneManager.LoadScene(0);
    }

    public void Volume() {
        audioMixer.SetFloat("volume", slider.value);
        volVal.text = (slider.value + 80).ToString("0.00");

    }
}
