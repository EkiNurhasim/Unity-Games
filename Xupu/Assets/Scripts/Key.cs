using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    private SpriteRenderer sprite;
    private CircleCollider2D circle;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (sprite.color == Color.green)
        {
            circle.enabled = false;
        }
    }

}
