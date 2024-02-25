using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

    //private string APP_ID = "ca-app-pub-9767192976869867~3194234272";

    
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Text progressText;

    [SerializeField] private AudioSource[] audioFx;
    //private int count = 0;

    // <meta-data
    //android:name="com.RuneTeam.Xupu"
    //android:value="ca-app-pub-9767192976869867~3194234272"/>

    //private RewardBasedVideoAd rewardVideoAD;
    // Real Ad
    //private string video_ID = "ca-app-pub-9767192976869867/6798437364";
    // Test Ad
    //private string video_ID = "ca-app-pub-3940256099942544/5224354917";


    //private void Start()
    //{
    //    ADManager.instance.RequestBanner();
    //}

    //public void RequestVideoAD()
    //{
    //    rewardVideoAD = RewardBasedVideoAd.Instance;

    //    AdRequest adRequest = new AdRequest.Builder().Build();
    //    rewardVideoAD.LoadAd(adRequest, video_ID);

    //}

    //public void DisplayVideoAd()
    //{
    //    if (rewardVideoAD.IsLoaded())
    //    {
    //        rewardVideoAD.Show();
    //    }
    //    else
    //    {
    //        Debug.Log("Fail to display");
    //    }
    //}



    public void NextScene(string scene)
    {
        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx[0].Play();
        else
            audioFx[0].Stop();

        StartCoroutine(LoadLevel(scene));
        MovePortal.notMove = false;
        Player.health = 3;
        Finish.bulletMove = false;
        PauseMenu.pause = false;
        GameManager.instance.manualController =  PlayerPrefs.GetString("manual");
        GameManager.instance.joystickController =  PlayerPrefs.GetString("joy");
    }

    public void OpenLevel1(string scene)
    {
        if (LevelManager.openLevel[0] == "true")
        {
            string sound = PlayerPrefs.GetString("sfx");
            if (sound == "true")
                audioFx[0].Play();
            else
                audioFx[0].Stop();

            //if (!(Application.internetReachability == NetworkReachability.NotReachable))
            //{
            //    count++;
            //    if (count == 1)
            //    {
            //        DisplayVideoAd();
            //        count = 0;
            //    }
            //}

            ADManager.instance.ShowRewardVideoAd();

            StartCoroutine(LoadLevel(scene));
            MovePortal.notMove = false;
            Player.health = 3;
            Finish.bulletMove = false;
            PauseMenu.pause = false;
            GameManager.instance.manualController =  PlayerPrefs.GetString("manual");
            GameManager.instance.joystickController =  PlayerPrefs.GetString("joy");
        }
        else
        {
            string sound1 = PlayerPrefs.GetString("sfx");
            if (sound1 == "true")
                audioFx[1].Play();
            else
                audioFx[1].Stop();
        }
    }

    public void OpenLevel2(string scene)
    {
        if (LevelManager.openLevel[1] == "true")
        {
            string sound = PlayerPrefs.GetString("sfx");
            if (sound == "true")
                audioFx[0].Play();
            else
                audioFx[0].Stop();

            //if (!(Application.internetReachability == NetworkReachability.NotReachable))
            //{
            //    count++;
            //    if (count == 1)
            //    {
            //        DisplayVideoAd();
            //        count = 0;
            //    }
            //}

            ADManager.instance.ShowRewardVideoAd();

            StartCoroutine(LoadLevel(scene));
            MovePortal.notMove = false;
            Player.health = 3;
            Finish.bulletMove = false;
            PauseMenu.pause = false;
            GameManager.instance.manualController =  PlayerPrefs.GetString("manual");
            GameManager.instance.joystickController =  PlayerPrefs.GetString("joy");
        }
        else
        {
            string sound1 = PlayerPrefs.GetString("sfx");
            if (sound1 == "true")
                audioFx[1].Play();
            else
                audioFx[1].Stop();
        }
    }

    public void OpenLevel3(string scene)
    {
        if (LevelManager.openLevel[2] == "true")
        {
            string sound = PlayerPrefs.GetString("sfx");
            if (sound == "true")
                audioFx[0].Play();
            else
                audioFx[0].Stop();

            //if (!(Application.internetReachability == NetworkReachability.NotReachable))
            //{
            //    count++;
            //    if (count == 1)
            //    {
            //        DisplayVideoAd();
            //        count = 0;
            //    }
            //}

            ADManager.instance.ShowRewardVideoAd();

            StartCoroutine(LoadLevel(scene));
            MovePortal.notMove = false;
            Player.health = 3;
            Finish.bulletMove = false;
            PauseMenu.pause = false;
            GameManager.instance.manualController =  PlayerPrefs.GetString("manual");
            GameManager.instance.joystickController =  PlayerPrefs.GetString("joy");
        }
        else
        {
            string sound1 = PlayerPrefs.GetString("sfx");
            if (sound1 == "true")
                audioFx[1].Play();
            else
                audioFx[1].Stop();
        }
    }

    public void OpenLevel4(string scene)
    {
        if (LevelManager.openLevel[3] == "true")
        {
            string sound = PlayerPrefs.GetString("sfx");
            if (sound == "true")
                audioFx[0].Play();
            else
                audioFx[0].Stop();

            //if (!(Application.internetReachability == NetworkReachability.NotReachable))
            //{
            //    count++;
            //    if (count == 1)
            //    {
            //        DisplayVideoAd();
            //        count = 0;
            //    }
            //}

            ADManager.instance.ShowRewardVideoAd();

            StartCoroutine(LoadLevel(scene));
            MovePortal.notMove = false;
            Player.health = 3;
            Finish.bulletMove = false;
            PauseMenu.pause = false;
            GameManager.instance.manualController =  PlayerPrefs.GetString("manual");
            GameManager.instance.joystickController =  PlayerPrefs.GetString("joy");
        }
        else
        {
            string sound1 = PlayerPrefs.GetString("sfx");
            if (sound1 == "true")
                audioFx[1].Play();
            else
                audioFx[1].Stop();
        }
    }

    public void OpenLevel5(string scene)
    {
        if (LevelManager.openLevel[4] == "true")
        {
            string sound = PlayerPrefs.GetString("sfx");
            if (sound == "true")
                audioFx[0].Play();
            else
                audioFx[0].Stop();

            //if (!(Application.internetReachability == NetworkReachability.NotReachable))
            //{
            //    count++;
            //    if (count == 1)
            //    {
            //        DisplayVideoAd();
            //        count = 0;
            //    }
            //}

            ADManager.instance.ShowRewardVideoAd();

            StartCoroutine(LoadLevel(scene));
            MovePortal.notMove = false;
            Player.health = 3;
            Finish.bulletMove = false;
            PauseMenu.pause = false;
            GameManager.instance.manualController =  PlayerPrefs.GetString("manual");
            GameManager.instance.joystickController =  PlayerPrefs.GetString("joy");
        }
        else
        {
            string sound1 = PlayerPrefs.GetString("sfx");
            if (sound1 == "true")
                audioFx[1].Play();
            else
                audioFx[1].Stop();
        }
    }

    public void OpenLevel6(string scene)
    {
        if (LevelManager.openLevel[5] == "true")
        {
            string sound = PlayerPrefs.GetString("sfx");
            if (sound == "true")
                audioFx[0].Play();
            else
                audioFx[0].Stop();

            //if (!(Application.internetReachability == NetworkReachability.NotReachable))
            //{
            //    count++;
            //    if (count == 1)
            //    {
            //        DisplayVideoAd();
            //        count = 0;
            //    }
            //}

            ADManager.instance.ShowRewardVideoAd();

            StartCoroutine(LoadLevel(scene));
            MovePortal.notMove = false;
            Player.health = 3;
            Finish.bulletMove = false;
            PauseMenu.pause = false;
            GameManager.instance.manualController =  PlayerPrefs.GetString("manual");
            GameManager.instance.joystickController =  PlayerPrefs.GetString("joy");
        }
        else
        {
            string sound1 = PlayerPrefs.GetString("sfx");
            if (sound1 == "true")
                audioFx[1].Play();
            else
                audioFx[1].Stop();
        }
    }

    public void OpenLevel7(string scene)
    {
        if (LevelManager.openLevel[6] == "true")
        {
            string sound = PlayerPrefs.GetString("sfx");
            if (sound == "true")
                audioFx[0].Play();
            else
                audioFx[0].Stop();

            //if (!(Application.internetReachability == NetworkReachability.NotReachable))
            //{
            //    count++;
            //    if (count == 1)
            //    {
            //        DisplayVideoAd();
            //        count = 0;
            //    }
            //}

            ADManager.instance.ShowRewardVideoAd();

            StartCoroutine(LoadLevel(scene));
            MovePortal.notMove = false;
            Player.health = 3;
            Finish.bulletMove = false;
            PauseMenu.pause = false;
            GameManager.instance.manualController =  PlayerPrefs.GetString("manual");
            GameManager.instance.joystickController =  PlayerPrefs.GetString("joy");
        }
        else
        {
            string sound1 = PlayerPrefs.GetString("sfx");
            if (sound1 == "true")
                audioFx[1].Play();
            else
                audioFx[1].Stop();
        }
    }

    public void OpenLevel8(string scene)
    {
        if (LevelManager.openLevel[7] == "true")
        {
            string sound = PlayerPrefs.GetString("sfx");
            if (sound == "true")
                audioFx[0].Play();
            else
                audioFx[0].Stop();

            //if (!(Application.internetReachability == NetworkReachability.NotReachable))
            //{
            //    count++;
            //    if (count == 1)
            //    {
            //        DisplayVideoAd();
            //        count = 0;
            //    }
            //}

            ADManager.instance.ShowRewardVideoAd();

            StartCoroutine(LoadLevel(scene));
            MovePortal.notMove = false;
            Player.health = 3;
            Finish.bulletMove = false;
            PauseMenu.pause = false;
            GameManager.instance.manualController =  PlayerPrefs.GetString("manual");
            GameManager.instance.joystickController =  PlayerPrefs.GetString("joy");
        }
        else
        {
            string sound1 = PlayerPrefs.GetString("sfx");
            if (sound1 == "true")
                audioFx[1].Play();
            else
                audioFx[1].Stop();
        }
    }

    public void OpenLevel9(string scene)
    {
        if (LevelManager.openLevel[8] == "true")
        {
            string sound = PlayerPrefs.GetString("sfx");
            if (sound == "true")
                audioFx[0].Play();
            else
                audioFx[0].Stop();

            //if (!(Application.internetReachability == NetworkReachability.NotReachable))
            //{
            //    count++;
            //    if (count == 1)
            //    {
            //        DisplayVideoAd();
            //        count = 0;
            //    }
            //}

            ADManager.instance.ShowRewardVideoAd();

            StartCoroutine(LoadLevel(scene));
            MovePortal.notMove = false;
            Player.health = 3;
            Finish.bulletMove = false;
            PauseMenu.pause = false;
            GameManager.instance.manualController =  PlayerPrefs.GetString("manual");
            GameManager.instance.joystickController =  PlayerPrefs.GetString("joy");
        }
        else
        {
            string sound1 = PlayerPrefs.GetString("sfx");
            if (sound1 == "true")
                audioFx[1].Play();
            else
                audioFx[1].Stop();
        }
    }

    public void CurrentScene()
    {

        string sound = PlayerPrefs.GetString("sfx");
        if (sound == "true")
            audioFx[0].Play();
        else
            audioFx[0].Stop();

        ADManager.instance.ShowInterstitialAd();

        MovePortal.notMove = false;
        Player.health = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PauseMenu.pause = false;
        Finish.bulletMove = false;
        GameManager.instance.manualController =  PlayerPrefs.GetString("manual");
        GameManager.instance.joystickController =  PlayerPrefs.GetString("joy");
    }

    IEnumerator LoadLevel(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            for (int i = 0; i <= 100; i++)
            {
                progressText.text = i + "%";
            }

            yield return null;
        }
    }
	
}
