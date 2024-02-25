using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ellipse : MonoBehaviour {

    [SerializeField] private SpriteRenderer[] other;

    private SpriteRenderer sprite;
    private CircleCollider2D circle;

	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
	}
	
	void Update ()
    {
        if (other[0].color == Color.green &&
            other[1].color == Color.green && 
            other[2].color == Color.green && 
            other[3].color == Color.green){

            sprite.color = Color.green;
            circle.enabled = false;
        }
	}
}
