using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Player player;

    bool inactive = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (inactive == false)
        {
            if (other.tag == "Hole")
            {
                player.AddScore();
                Destroy(this.gameObject);
            }
            if (other.tag == "Player" || other.tag == "Enemy")
            {
                player.TakeDemage();
                speed = 0;
                transform.parent = player.transform;
            }
            inactive = true;
        }
    }
}
