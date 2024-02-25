using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SmallEnemyCircle : MonoBehaviour {

    [SerializeField] private GameObject Deathfx;
    [SerializeField] private GameObject livefx;
    GameObject player;
    [SerializeField] private Transform startPoint;

    private Animator animCamera;
    [SerializeField]private AudioSource[] audioFx;

    private void Awake()
    {
        animCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animCamera.SetTrigger("shake");
            string sound = PlayerPrefs.GetString("sfx");
            if (sound == "true")
                audioFx[0].Play();
            else
                audioFx[0].Stop();

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
                //other.transform.position = startPoint.transform.position;
                other.GetComponent<PlayerBounds>().enabled = false;
                other.transform.position = new Vector2(0, 1000f);
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
        Instantiate(livefx, startPoint.transform.position, Quaternion.identity);
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx[1].Play();
        else
            audioFx[1].Stop();

        animCamera.SetTrigger("shake");
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<TrailRenderer>().enabled = true;
        Player.speed = 5f;
        Player.dash = 100f;
    }
}
