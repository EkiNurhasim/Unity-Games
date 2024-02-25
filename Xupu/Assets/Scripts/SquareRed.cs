using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareRed : MonoBehaviour
{

    [SerializeField] private GameObject Deathfx;
    [SerializeField] private GameObject livefx;
    GameObject player;
    [SerializeField] private Transform startPoint;

    private Animator animCamera;
    private Animator anim;
    [SerializeField] AudioSource[] audioFx;

    private void Awake()
    {
        animCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("squarered");
            StartCoroutine("PlayerOn");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine("PlayerOn");
        }
    }

    private IEnumerator WaitPlayer()
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

    private IEnumerator PlayerOn()
    {
        yield return new WaitForSeconds(.5f);

        animCamera.SetTrigger("shake");
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx[0].Play();
        else
            audioFx[0].Stop();
        player.transform.position = startPoint.transform.position;
        Player.speed = 0f;
        Player.dash = 0f;
        Player.health--;
        Instantiate(Deathfx, transform.position, Quaternion.identity);

        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<TrailRenderer>().enabled = false;

        if (Player.health == 0)
        {
            player.GetComponent<PlayerBounds>().enabled = false;
            player.transform.position = new Vector2(0, 1000f);
            //player.transform.position = startPoint.transform.position;
            Player.speed = 5f;
            Player.dash = 100f;
            Player.health = 0;
        }
        else
        {
            StartCoroutine("WaitPlayer");
        }
    }



}
