using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField] public static string[] openLevel = new string[9];
    [SerializeField] Image[] levelImage;
    [SerializeField] private GameObject[] levelSprite;

    private void Awake()
    {
        openLevel[0] = "false";
        openLevel[1] = "false";
        openLevel[2] = "false";
        openLevel[3] = "false";
        openLevel[4] = "false";
        openLevel[5] = "false";
        openLevel[6] = "false";
        openLevel[7] = "false";
        openLevel[8] = "false";
    }

    void Update ()
    {
        for (int i = 0; i < levelImage.Length; i++)
        {
            if (openLevel[i] == "true")
            {
               levelImage[i].sprite = levelSprite[i].GetComponent<SpriteRenderer>().sprite;
            }
        }


        if (PauseMenu.pause)
        {
            Time.timeScale = 1;
        }

        Save();
    }

    // SAVE
    private void Save()
    {
        for (int i = 0; i < openLevel.Length; i++)
        {
            openLevel[i] = (PlayerPrefs.GetString("level" + i));
        }

    }



}
