using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;





public class LevelBounds
{    

    public float width; 
    public float height; 
    public SnakeController snakeController;
   

    public LevelBounds (float width, float height)
    {
        this.width = width;
        this.height = height;
    }

   
   
    private void Awake()
    {
        snakeController.gridPosition = gridPosition;
    }
    
    public Vector2 WrapFunction(Vector2 gridPosition)
    {
         if(gridPosition.x < 0)
         {
            gridPosition.x = width -1;
         }

         if (gridPosition.y < 0)
         {
            gridPosition.y = height -1;
         }

         return gridPosition;
    }
   
    
    
}
