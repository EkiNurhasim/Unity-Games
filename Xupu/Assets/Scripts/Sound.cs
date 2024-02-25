using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class Sound : MonoBehaviour {

    public string sfx ;
    public string bgm ;
    [SerializeField] private GameObject canvasSound;
    [SerializeField] private Image sfxImage;
    [SerializeField] private Image bgmImage;
    [SerializeField] private Color red;
    [SerializeField] private Color white;

    private bool canvas;
    public bool s;
    public bool b;

    private AudioSource audioFx;
    [SerializeField] AudioSource audioBgm;

    private void Awake()
    {
        audioFx = GetComponent<AudioSource>();
        PlayerPrefs.SetString("sfx", sfx);
        PlayerPrefs.SetString("bgm", bgm);
    }

    private void Update ()
    {
        if (canvas == true)
        {
            canvasSound.SetActive(true);
        }
        else
        {
            canvasSound.SetActive(false);
        }
	}

    public void OpenCanvasSound()
    {
        canvas = !canvas;
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx.Play();
        else
            audioFx.Stop();
    }

    public void SFX()
    {
        s = !s;
        if (s == true)
        {
            sfx = "true";
            PlayerPrefs.SetString("sfx", sfx);
        }
        else
        {
            sfx = "false";
            PlayerPrefs.SetString("sfx", sfx); 
        }

        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
        {
            audioFx.Play();
            sfxImage.color = white;
        }
        else
        {
            audioFx.Stop();
            sfxImage.color = red;
        }
    }

    public void BGM()
    {
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
        {
            audioFx.Play();
        }
        else
        {
            audioFx.Stop();
        }

        b = !b;
        if (b == true)
        {
            bgm = "true";
            bgmImage.color = white;
            PlayerPrefs.SetString("bgm", bgm);
        }
        else
        {
            bgm = "false";
            bgmImage.color = red;
            PlayerPrefs.SetString("bgm", bgm);
        }

        string sound1 = PlayerPrefs.GetString("bgm");
        if (sound1 == "true")
        {
            audioBgm.Play();
        }
        else
        {
            audioBgm.Stop();
        }
    }
}
