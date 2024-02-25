using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm : MonoBehaviour {

    public static AudioSource audioBgm;
	
	void Awake ()
    {
        audioBgm = GetComponent<AudioSource>();
        string sound = PlayerPrefs.GetString("bgm");
        if (sound == "true")
        {
            audioBgm.Play();
        }
        else
        {
            audioBgm.Stop();
        }
    }

    private void Update()
    {
        if (PauseMenu.pause == true || Player.health == 0 || Finish.bulletMove == true)
        {
            if (audioBgm.isPlaying == true)
            {
                audioBgm.Stop();
            }
        }
        else
        {
            if (audioBgm.isPlaying == false)
            {
                audioBgm.Play();
            }
        }
    }
}
