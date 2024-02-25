using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    [SerializeField] private GameObject pausePanel;
    public static bool pause = false;
    private AudioSource audioFx;

    private void Awake()
    {
        ADManager.instance.HideBannerAd();
        audioFx = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (pause)
        {
            var bullet = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (var item in bullet)
            {
                item.GetComponent<AudioSource>().enabled = false;
            }

            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            var bullet = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (var item in bullet)
            {
                item.GetComponent<AudioSource>().enabled = true;
                if (!item.GetComponent<AudioSource>().isPlaying)
                {
                    item.GetComponent<AudioSource>().Play();
                }
            }
            
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void BtnPause()
    {
        pause = !pause;
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx.Play();
        else
            audioFx.Stop();
    }

    public void BtnQuit()
    {
        Application.Quit();
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx.Play();
        else
            audioFx.Stop();
    }

    public void BtnMainMenu(string mainMenu)
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1;
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx.Play();
        else
            audioFx.Stop();
    }

}
