using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject sound;
    public GameObject moveSpeed;
    public GameObject lookSpeed;

    private GameObject player;

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
    public void UpdateMoveSpeed()
    {
        moveSpeed.GetComponentInChildren<Text>().text = "Player speed: " + Mathf.RoundToInt(moveSpeed.GetComponent<Slider>().value * 100) + "%";
        PlayerPrefs.SetFloat("MoveSpeed", moveSpeed.GetComponent<Slider>().value);

        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)//If player is also active (Game is running) update its value
        {
            player.GetComponent<PlayerView1stPerson>().moveSpeed = moveSpeed.GetComponent<Slider>().value;
        }
    }

    public void UpdateLookSpeed()
    {
        lookSpeed.GetComponentInChildren<Text>().text = "Player speed: " + Mathf.RoundToInt(lookSpeed.GetComponent<Slider>().value * 100) + "%";
        PlayerPrefs.SetFloat("LookSpeed", lookSpeed.GetComponent<Slider>().value);

        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)//If player is also active (Game is running) update its value
        {
            player.GetComponent<PlayerView1stPerson>().lookSpeed = lookSpeed.GetComponent<Slider>().value;
        }
    }
}
