using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePortal : MonoBehaviour {

    public static bool notMove = false;

    [SerializeField] private GameObject FXmove;
    [SerializeField] private PlayerBounds playerBounds;
	[SerializeField] private GameObject[] mainCamera;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject startPoint;
	[SerializeField] private GameObject newStartPoint;

    private AudioSource audioFx;

    private void Awake()
    {
        audioFx = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player"))
		{
            string sound = PlayerPrefs.GetString("sfx");
            if (sound == "true")
                audioFx.Play();
            else
                audioFx.Stop();

            notMove = true;
            Instantiate(FXmove, player.transform.position, Quaternion.identity);
            other.GetComponent<SpriteRenderer>().enabled = false;
            other.GetComponent<TrailRenderer>().enabled = false;
            other.GetComponent<BoxCollider2D>().enabled = false;

            playerBounds.enabled = false;
			startPoint.transform.position = newStartPoint.transform.position;
            player.transform.position = newStartPoint.transform.position;
            StartCoroutine(Move());
		}
	}

    IEnumerator Move()
    {
        yield return new WaitForSeconds(1f);
        mainCamera[0].GetComponent<Camera>().enabled = false;
        mainCamera[1].GetComponent<Camera>().enabled = true;
        Instantiate(FXmove, player.transform.position, Quaternion.identity);
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx.Play();
        else
            audioFx.Stop();
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<TrailRenderer>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;

    }

}
