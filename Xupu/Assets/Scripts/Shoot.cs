using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    [SerializeField] private GameObject projectile;
    [SerializeField] private float time;
    private bool shoot;

    private void Awake()
    {
        shoot = false;
    }

    private void Update ()
    {
        if (shoot == true)
        {
            time += Time.deltaTime ;
            if (time >= 0.1f)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                time = 0;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shoot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shoot = false;
        }
    }
}
