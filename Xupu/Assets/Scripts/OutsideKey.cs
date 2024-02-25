using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideKey : MonoBehaviour {

    private SpriteRenderer sprite;
    private AudioSource audioFx;

    private void Awake()
    {
        audioFx = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string sound = PlayerPrefs.GetString("sfx");
            if (sound == "true")
                audioFx.Play();
            else
                audioFx.Stop();

            sprite.color = Color.green;
        }
    }

}
