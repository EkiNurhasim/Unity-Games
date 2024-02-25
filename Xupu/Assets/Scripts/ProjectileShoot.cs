using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour {

    [SerializeField] GameObject fx;
    [SerializeField] float speed;

    AudioSource audioFx;
    Rigidbody2D rig;

	void Awake ()
    {
        audioFx = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();

        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx.Play();
        else
            audioFx.Stop();
    }

    void FixedUpdate()       
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            LastBozz.health--;
            Instantiate(fx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
