using System.Collections;
using GoogleMobileAds.Api;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public string joystickController = "false";
    public string manualController = "true";
    [SerializeField] private GameObject controller;

    private AudioSource audioFx;

    public void Awake()
    {
        audioFx = GetComponent<AudioSource>();

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
    public void ManualController()
    {
        manualController = "true";
        joystickController = "false";
        PlayerPrefs.SetString("manual", manualController);
        PlayerPrefs.SetString("joy", joystickController);
        controller.SetActive(false);
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx.Play();
        else
            audioFx.Stop();
    }

    public void JoyStickController()
    {
        manualController = "false";
        joystickController = "true";
        PlayerPrefs.SetString("manual", manualController);
        PlayerPrefs.SetString("joy", joystickController);
        controller.SetActive(false);
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx.Play();
        else
            audioFx.Stop();
    }

    public void OpenController()
    {
        controller.SetActive(true);
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx.Play();
        else
            audioFx.Stop();
    }
  
}