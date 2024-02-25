using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {


    [SerializeField] private GameObject quit;
    private bool openQuit;
    private AudioSource audioFx;

    private void Awake()
    {
        openQuit = false;
        audioFx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (openQuit)
        {
            quit.SetActive(true);
        }
        else
        {
            quit.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx.Play();
        else
            audioFx.Stop();
    }

    public void OpenQuit()
    {
        openQuit = !openQuit;
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx.Play();
        else
            audioFx.Stop();
    }
}
