using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeController : MonoBehaviour
{
 
    private  enum State
    {
        Alive,
        Dead,
    }
 
// Snake Parameters
    private State state;
    private Vector2 movementDir;
    private Vector2 gridPosition;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private List<Transform> Body;
    public Transform segmentPrefab;
    
    public GameObject deathUI;

   
   

    
    private void Start()
    {
        Body = new List<Transform>();
        Body.Add(this.transform);
        
        
    }
    private void Awake()
    {
        gridPosition = new Vector2(0f,0f);
        gridMoveTimerMax = 0.5f;
        gridMoveTimer = gridMoveTimerMax;
        movementDir = new Vector2 (1f,0f);
        state = State.Alive;
        
        
        
        
    }

   
   //Update
   private void Update()

    {
     switch (state)
     {
        case State.Alive:
         InputHandler();
            break;
        case State.Dead:
            break;
     }
     
       
      
    }
    //FixedUpdate
    private void FixedUpdate()
    {
       switch (state)
       {
        case State.Alive:
         MovementHandler();
          break;
        case State.Dead:
          break;

       }

       
        
        
    }
        
       
    // Snake Inputs
    private void InputHandler()
    {
        if(gameObject.tag == "Player")
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

        else if (gameObject.tag == "Player2")
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {   
                if(movementDir.y!= -1)
                {
                movementDir.x = 0f;
                movementDir.y = +1f;
                }
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                if(movementDir.y!= +1)
                {
                movementDir.x = 0f;
                movementDir.y = -1f;
                }
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if(movementDir.x!= +1)
                {
                movementDir.x = -1f;
                movementDir.y  = 0f;
                }
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                if(movementDir.x!= -1)
                {
                movementDir.x = +1;
                movementDir.y  = 0f;
                }

            }
        }

        
    
    }
  // Snake Movement
    private void MovementHandler()
    {
        
        gridMoveTimer += Time.fixedDeltaTime;

        if(gridMoveTimer >= gridMoveTimerMax)
        {
           
            gridMoveTimer = 0;
            gridPosition += movementDir;
         //Screen wrapping functions to wrap snake around when out of camera's view 
             WrapAroundHz();
             WrapAroundVt();

         // snake death function to cease movement and declare it dead
             SnakeDeath();

         // loop to make the snake segments follow and move along with snake's head
             
            for(int i = Body.Count-1 ; i > 0 ;  i--)
             {
               Body[i].position = Body[i-1].position;
             }
         // to move snake's head
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
    public void Grow()
    {
       
      Transform body = Instantiate(this.segmentPrefab);
      body.position = Body[Body.Count -1].position;
      Body.Add(body);
      
    } 

    public void Shrink()
    {
        if(Body.Count > 3)
        {
             Destroy(Body[Body.Count - 1].gameObject);
            Body.RemoveAt(Body.Count - 1);
        }
        else
        {
             SnakeDeath();
        }
    }

    

    //Snake Death
    private void SnakeDeath()
    {
        foreach (var body in Body)
        {
            Vector2 BpGridPosition = body.position;

            if (gridPosition == BpGridPosition)
            {
                // GameOver
                Invoke("LoadDeathUI", 1f);
                state = State.Dead;
                
            }
        }
    }
 
   //Gameover screen
    public void LoadDeathUI()
    {
        deathUI.SetActive(true);
        Time.timeScale = 0f;
    }

    private void WrapAroundHz()
    {
        //Horizontal wrap  
             if(gridPosition.x == -19f)
             {
                gridPosition.x = 19f;
             }
             else if(gridPosition.x == 19f)
             {
                gridPosition.x = -19f;
             }
    }

    private void WrapAroundVt()
    {
       //Vertical wrap
             if(gridPosition.y == -16f)
              {
                gridPosition.y = 16f;
              }
             else if(gridPosition.y == 16f)
             {
                gridPosition.y = -16f;
             }
    }
}
