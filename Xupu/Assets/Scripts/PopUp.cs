using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PopUp : MonoBehaviour {

    [SerializeField] private GameObject[] popUp;
    [SerializeField] private float currentTime = 1f;

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (Player.health == 3)
        {
            if (currentTime > 2f)
            {
                popUp[0].SetActive(true);
            }
        }
    }

    public void PopUp1()
    {
        popUp[0].SetActive(false);
        popUp[1].SetActive(true);
        popUp[2].SetActive(false);
        popUp[3].SetActive(false);
    }

    public void PopUp2()
    {
        popUp[0].SetActive(false);
        popUp[1].SetActive(false);
        popUp[2].SetActive(true);
        popUp[3].SetActive(false);
    }

    public void PopUp3()
    {
        popUp[0].SetActive(false);
        popUp[1].SetActive(false);
        popUp[2].SetActive(false);
        popUp[3].SetActive(true);
    }

    public void PopUp4()
    {
        popUp[0].SetActive(false);
        popUp[1].SetActive(false);
        popUp[2].SetActive(false);
        popUp[3].SetActive(false);
        gameObject.SetActive(false);
    }
}
