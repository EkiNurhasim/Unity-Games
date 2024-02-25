using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    
    void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Transform>();
    }

  
    void FixedUpdate()
    {
        transform.position = player.transform.position;
    }
}
