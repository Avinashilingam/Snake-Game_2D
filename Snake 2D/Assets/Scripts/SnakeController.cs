using System;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
 
 // Snake Movement

    private Vector2 movementDir;
    private Vector2 gridPosition;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private List<Transform> Body;
    public Transform segmentPrefab;
    private BoxCollider2D levelBounds;
    private FoodController foodController;
   // private  int defSegmentSize = 4;
    
   

    
    private void Start()
    {
        Body = new List<Transform>();
        Body.Add(this.transform);
    }
    private void Awake()
    {
        gridPosition = new Vector2(0f,0f);
        gridMoveTimerMax = 0.25f;
        gridMoveTimer = gridMoveTimerMax;
        movementDir = new Vector2 (1f,0f);
        
    }

   
   
   private void Update()

    {
       InputHandler();
    }
    
    private void FixedUpdate()
    {
       
        MovementHandler();
    }
        
       
    // Snake Inputs
    private void InputHandler()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {   
            if(movementDir.y!= -1)
            {
             movementDir.x = 0f;
             movementDir.y = +1f;
            }
        }
         else if(Input.GetKeyDown(KeyCode.S))
        {
            if(movementDir.y!= +1)
            {
            movementDir.x = 0f;
            movementDir.y = -1f;
            }
        }
         else if(Input.GetKeyDown(KeyCode.A))
        {
            if(movementDir.x!= +1)
            {
             movementDir.x = -1f;
             movementDir.y  = 0f;
            }
        }
         else if(Input.GetKeyDown(KeyCode.D))
        {
            if(movementDir.x!= -1)
            {
              movementDir.x = +1;
              movementDir.y  = 0f;
            }

        }

        
    
    }
  // Snake Movement
    private void MovementHandler()
    {
        
        gridMoveTimer += Time.deltaTime;

        if(gridMoveTimer >= gridMoveTimerMax)
        {
            gridMoveTimer -= gridMoveTimerMax;
            gridPosition += movementDir;

             for(int i = Body.Count-1 ; i > 0 ;  i--)
        {
            Body[i].position = Body[i-1].position;
        }

        transform.position = new Vector3(gridPosition.x,gridPosition.y);
        transform.eulerAngles = new Vector3(0,0,GetAngleFromVector(movementDir) -90);

            
        }
         
   
      
    }

  // Snake Rotation

   private float GetAngleFromVector(Vector2 dir){
       float n = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
       if(n<0) n += 360;
       return n;
   }
  // Snake Growth 
    private void Grow()
    {
      Transform body = Instantiate(this.segmentPrefab);
      body.position = Body[Body.Count -1].position;
      Body.Add(body);
      
    } 

    private void OnTriggerEnter2D(Collider2D other)
 {
     if(other.tag == "Food")
     {
        Grow();
     }
 }
}
