using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Note : MonoBehaviour {


    [SerializeField] private GameObject note;
    private bool openNoteReset;
    private AudioSource audioFx;

    private void Awake()
    {
        openNoteReset = false;
        audioFx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (openNoteReset)
        {
            note.SetActive(true);
        }
        else
        {
            note.SetActive(false);
        }
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    public void OpenNoteReset()
    {
        openNoteReset = !openNoteReset;
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
