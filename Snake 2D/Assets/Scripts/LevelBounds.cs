
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;





public class LevelBounds : MonoBehaviour
{    

    public float width; 
    public float height; 
    public SnakeController snakeController;
    private Vector2 gP;

    
    private void Awake()
    {
        width = gameObject.GetComponent<BoxCollider2D>().size.x;
        // Debug.Log("width is " + width);
        height = gameObject.GetComponent<BoxCollider2D>().size.y;
        // Debug.Log("height is "+height);
        
        // Debug.Log(gP.x);
        // snakeController =
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        gP = snakeController.gridPosition;
        Debug.Log(gP.x + " " + gP.y);
        WrapFunction(gP);
    }
    public Vector2 WrapFunction(Vector2 gridPosition)
    {
        if(gP.x < -18)
        {
            gP.x = 18; //gP.x = 37.62 - 1 = 36.62
        }

        if(gP.y < -15)
        {
            gP.y = 15;
        }

        return gP;
    }

    private Vector2 OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            WrapFunction(gP);
        }

        return gP;
    }

    
    
}
