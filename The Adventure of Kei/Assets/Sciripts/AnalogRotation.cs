using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogRotation : MonoBehaviour
{
    [SerializeField] private int rotationOffset = 90;

    private GameObject kNob;

    private void Awake()
    {
        kNob = GameObject.Find("Knob");
    }

    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(kNob.transform.position * rotationOffset) - transform.position;
        //difference.Normalize();

        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }

}
