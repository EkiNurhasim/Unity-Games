using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveZone : MonoBehaviour {

    [SerializeField] GameObject[] topBottom;
    [SerializeField] GameObject[] duris;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < topBottom.Length; i++)
            {
                topBottom[i].GetComponent<BoxCollider2D>().enabled = false;
                duris[i].GetComponent<CircleCollider2D>().enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < topBottom.Length; i++)
            {
                topBottom[i].GetComponent<BoxCollider2D>().enabled = true;
                duris[i].GetComponent<CircleCollider2D>().enabled = true;
            }
        }
    }

}
