using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Setting : MonoBehaviour {

	private bool push;
	private Animator anim;
    private AudioSource audioFx;

    private void Start()
	{
		anim = GetComponent<Animator>();
        audioFx = GetComponent<AudioSource>();
	}
	private void Update () 
	{
		if ( push )
		{
			anim.SetBool("mask", true);
		}else
		{
			anim.SetBool("mask", false);
		}
	}

	public void SettingAnim()
	{
		push = !push;
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
        {
            audioFx.Play();
        }
        else
        {
            audioFx.Stop();
        }
    }
}
