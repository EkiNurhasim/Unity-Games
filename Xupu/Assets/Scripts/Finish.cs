using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Finish : MonoBehaviour {
    
    [SerializeField] int openIndex = 0;
    [SerializeField] GameObject fx;
    [SerializeField] GameObject congratulation;

    public static bool bulletMove = false;

    private Animator animCamera;
    private AudioSource audioFx;

    private void Awake()
    {
        audioFx = GetComponent<AudioSource>();
        animCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
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

            animCamera.SetTrigger("shake");
            other.gameObject.SetActive(false);
            bulletMove = true;
            StartCoroutine("GameFinish");
        }
    }

    IEnumerator GameFinish()
    {
        Instantiate(fx, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(.1f);
        congratulation.SetActive(true);
        string level = LevelManager.openLevel[openIndex] = "true";
        PlayerPrefs.SetString("level" + openIndex, level);
    }
}
