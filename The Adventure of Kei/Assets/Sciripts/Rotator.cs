using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float speedRotation = 100f;

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0f, 0f, speedRotation * Time.fixedDeltaTime));
    }
}
