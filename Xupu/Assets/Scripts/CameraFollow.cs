using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour{

    public Transform other;

    private void Update()
    {
        transform.position = other.transform.position;
        if (LastBozz.health == 0)
        {
            Destroy(gameObject);
        }
    }
}