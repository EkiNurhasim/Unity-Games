using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderToOn : MonoBehaviour {

    [SerializeField] private SpriteRenderer circle;

    private PolygonCollider2D col;

    private void Awake()
    {
        col = GetComponent<PolygonCollider2D>();
        col.enabled = false;
    }

    private void Update()
    {
        if (circle.color == Color.green)
        {
            col.enabled = true;
        }
    }

}
