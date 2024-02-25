using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complate : MonoBehaviour {

    [SerializeField] GameObject complate;

	void Update ()
    {
        string com = PlayerPrefs.GetString("complate");
        if (com == "true")
        {
            complate.SetActive(true);
        }
    }
}
