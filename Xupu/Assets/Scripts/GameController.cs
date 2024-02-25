using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] private GameObject[] manual;
    [SerializeField] private GameObject joy;
    [SerializeField] private Image dashSprite;
    [SerializeField] private Sprite[] sprite;

    
	void Update ()
    {

        // if (GameManager.instance.manualController == "true" && GameManager.instance.joystickController == "true")
        // {
        //     return;
        // }

        if (GameManager.instance.manualController == "true" && GameManager.instance.joystickController == "false")
        {
            foreach (var item in manual)
            {
                item.gameObject.SetActive(true);
            }
            dashSprite.sprite = sprite[0];
            joy.gameObject.SetActive(false);
            

        }
        else if(GameManager.instance.manualController == "false" && GameManager.instance.joystickController == "true")
        {
            foreach (var item in manual)
            {
                item.gameObject.SetActive(false);
            }
            dashSprite.sprite = sprite[1];
            joy.gameObject.SetActive(true);
        }
	}

 
}
