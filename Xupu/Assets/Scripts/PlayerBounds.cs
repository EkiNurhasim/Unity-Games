using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour {

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;    
	
	private void Awake ()
    {
        Vector3 coor = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = coor.x - 0.3f;
        minX = -coor.x + 0.3f;
        maxY = coor.y - 0.3f;
        minY = -coor.y + 0.3f;
	}
	
	private void Update ()
    {
        // Bounds Player. Can't move to outside of Main Camera
        Vector3 temp = transform.position;

        if (temp.x > maxX)
            temp.x = maxX;
        if (temp.x < minX)
            temp.x = minX;
        if (temp.y > maxY)
            temp.y = maxY;
        if (temp.y < minY)
            temp.y = minY;

        transform.position = temp;
	}
}
