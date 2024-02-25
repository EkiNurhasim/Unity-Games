using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeControl : MonoBehaviour {

    [SerializeField] private GameObject[] rotator;
    [SerializeField] private float speed = 150f;
    [SerializeField] private float minSpeed = 50f;
    [SerializeField] private float maxSpeed = 150f;
    [SerializeField] private Text text;

    private bool timeControl;    

    void Update ()
    {
        for (int i = 0; i < rotator.Length; i++)
        {
            rotator[i].transform.Rotate(new Vector3(0f, 0f, speed * Time.deltaTime));
        }
        text.text = Mathf.Round(speed / 2) + "";

        if (timeControl == true)
        {
            speed -= Time.deltaTime * 5;
            if (speed <= minSpeed)
            {
                speed = minSpeed;
            }
        }
        if (timeControl == false)
        {
            speed += Time.deltaTime * 5;
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timeControl = true;
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timeControl = false;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
