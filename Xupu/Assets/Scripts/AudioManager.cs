using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    [SerializeField] AudioClip clip;
    private AudioSource sfx;

    private void Awake()
    {
        sfx = GetComponent<AudioSource>();
    }

    void Start ()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
	}
	
    public void PlayAudio()
    {
        sfx.Play();
    }

    public void StopAudio()
    {
        sfx.Stop();
    }
}
