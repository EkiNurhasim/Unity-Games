using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInAnotherCamera : MonoBehaviour {

    [SerializeField] private GameObject Deathfx;
    [SerializeField] private GameObject livefx;
    GameObject player;
    [SerializeField] private Transform startPoint;

    [SerializeField] private Animator animCamera;
    [SerializeField] private AudioSource[] audioFx;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string sound = PlayerPrefs.GetString("sfx");
            if (sound == "true")
                audioFx[0].Play();
            else
                audioFx[0].Stop();

            animCamera.SetTrigger("shake");
            Instantiate(Deathfx, other.transform.position, Quaternion.identity);
            other.transform.position = startPoint.transform.position;
            Player.speed = 0f;
            Player.dash = 0f;
            Player.health--;
            other.GetComponent<SpriteRenderer>().enabled = false;
            other.GetComponent<TrailRenderer>().enabled = false;

            if (Player.health == 0)
            {
                Player.health = 0;
                other.GetComponent<PlayerBounds>().enabled = false;
                other.transform.position = new Vector2(0, 1000f);
                //other.transform.position = startPoint.transform.position;
                Player.speed = 5f;
                Player.dash = 100f;
            }
            else
            {
                StartCoroutine("WaitPlayer");
            }

        }
    }

    IEnumerator WaitPlayer()
    {
        yield return new WaitForSeconds(1f);
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx[1].Play();
        else
            audioFx[1].Stop();
        Instantiate(livefx, startPoint.transform.position, Quaternion.identity);
        animCamera.SetTrigger("shake");
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<TrailRenderer>().enabled = true;
        Player.speed = 5f;
        Player.dash = 100f;
    }
}