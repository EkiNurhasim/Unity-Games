using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour {

    [SerializeField] private GameObject gameOverCanvas;

	void Update ()
    {
        if (Player.health == 0)
        {
            gameOverCanvas.SetActive(true);
        }
        else
        {
            gameOverCanvas.SetActive(false);
        }
	}
}
