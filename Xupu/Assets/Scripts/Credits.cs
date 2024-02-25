using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

    [SerializeField] private GameObject credit;
    private bool openCredits;
    private AudioSource audioFx;

    private void Awake()
    {
        openCredits = false;
        audioFx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (openCredits)
        {
            credit.SetActive(true);
        }
        else
        {
            credit.SetActive(false);
        }
    }

    public void OpenCredits()
    {
        openCredits = !openCredits;
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx.Play();
        else
            audioFx.Stop();
    }
}
