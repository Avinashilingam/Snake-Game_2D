using System.Globalization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;




public class LevelBounds 
{
    
    

    public float width = this.width;
    public float height = this.height;
    private SnakeController snakeController;
    public Vector2 gP = snakeController.gridPosition;

    public Vector2 WrapFunction(Vector2 gP)
    {
        if(gP.x < 0)
        {
            gP.x = width - 1;
        }

        if(gP.y < 0)
        {
            gP.y = height - 1;
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
