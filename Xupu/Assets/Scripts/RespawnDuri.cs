using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnDuri : MonoBehaviour {

    [SerializeField] private GameObject respawnDuri;
    [SerializeField] private float time;
    [SerializeField] private float fixedTime;

    private void Start()
    {
        Instantiate(respawnDuri, transform.position, Quaternion.identity);
    }

    void Update ()
    {
        if (time > 5f)
        {
            Instantiate(respawnDuri, transform.position, Quaternion.identity);
            time = fixedTime;
        }
        else
        {
            time += Time.deltaTime;
        }
	}
}
