using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLine : MonoBehaviour {

    [SerializeField] private SpriteRenderer[] outsideKeys;
    [SerializeField] private TrailRenderer[] keysTrail;
    [SerializeField] private GameObject[] pointKey;
    [SerializeField] private GameObject[] topBottom;

    private SpriteRenderer sprite;
    private BoxCollider2D box;

    private void Awake()
    {
        //foreach (var items in keysTrail)
        //{
        //    items.enabled = false;
        //}
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (outsideKeys[0].color == Color.green &&
            outsideKeys[1].color == Color.green &&
            outsideKeys[2].color == Color.green &&
            outsideKeys[3].color == Color.green)
        {

            // Move and Rotate the Keys inside the redline
            for (int i = 0; i < outsideKeys.Length; i++)
            {
                outsideKeys[i].transform.position = pointKey[i].transform.position;
                outsideKeys[i].transform.SetParent(pointKey[i].transform);
                keysTrail[i].enabled = true;
            }

            // Top And Bottom Disabled
            foreach (var topbottom in topBottom)
            {
                topbottom.gameObject.SetActive(false);
            }

            sprite.sprite = null;
            box.enabled = false;
        }
    }

}
