using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDuri : MonoBehaviour {

    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float timeToExplode;

    private Rigidbody2D rig;
    [SerializeField] private AudioSource audioFx;

	private void Awake ()
    {
        rig = GetComponent<Rigidbody2D>();

        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx.Play();
        else
            audioFx.Stop();

    }

    private void Update()
    {
        rig.velocity = new Vector2(speedX * Time.deltaTime, speedY * Time.deltaTime);

        timeToExplode += Time.deltaTime;
        if (timeToExplode > 5)
        {
            Destroy(gameObject);
        }
    }

    
}
