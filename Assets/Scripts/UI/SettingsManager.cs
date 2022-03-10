using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject sound;

    private void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            sound.GetComponent<Slider>().value = PlayerPrefs.GetFloat("volume");
            UpdateSound();
        }        
    }
    
    public void UpdateSound()
    {
        sound.GetComponentInChildren<Text>().text = "Volume " + Mathf.RoundToInt(sound.GetComponent<Slider>().value * 100) + "%";
        AudioListener.volume = sound.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("volume", sound.GetComponent<Slider>().value);
    }
}
