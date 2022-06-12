using System;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
 
    
 
// Snake Parameters
    private Vector2 movementDir;
    public Vector2 gridPosition;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private List<Transform> Body;
    public Transform segmentPrefab;
    private FoodController foodController;
   
   

    
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

   
   //Update
   private void Update()

    {
       InputHandler();
      
    }
    //FixedUpdate
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
           //Screen wrapping 
           //Horizontal wrap  
             if(gridPosition.x == -19f)
             {
                gridPosition.x = 19f;
             }
             else if(gridPosition.x == 19f)
             {
                gridPosition.x = -19f;
             }

          //Vertical wrap
             if(gridPosition.y == -16f)
              {
                gridPosition.y = 16f;
              }
             else if(gridPosition.y == 16f)
             {
                gridPosition.y = -16f;
             }
             
           for(int i = Body.Count-1 ; i > 0 ;  i--)
        {
            Body[i].position = Body[i-1].position;
        }
 //Snake Death
        foreach (var body in Body)
        {
            Vector2 BpGridPosition = body.position;

            if (gridPosition == BpGridPosition)
            {
                // GameOver
                Debug.Log("Dead");
            }
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
