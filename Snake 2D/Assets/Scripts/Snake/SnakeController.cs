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
    public Vector2 gridPosition;
    private float gridMoveTimer;
   [SerializeField] private float gridMoveTimerMax;
    private List<Transform> Body;
    public Transform segmentPrefab;
    [SerializeField] private LevelWrap  level;
    
    public GameObject deathUI;

    private float speed = 1f;

    bool isDead = true;
    private void Start()
    {
        Body = new List<Transform>();
        Body.Add(this.transform);  
    }

    
    private void Awake()
    {
        gridPosition = gameObject.transform.position;
        gridMoveTimer = gridMoveTimerMax;
        movementDir = new Vector2 (1f,0f);//setting the movement direction to 1 on x axis
        state = State.Alive;
    }

    // IsDead
    public void SetISDead(bool value)
    {
        isDead = value;
    }

    // Speed
    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed( float _speed)
    {
        speed = _speed;
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
         ScreenWrapHzt();
          break;
        case State.Dead:
        
          break;

       }
    }
        
       
    // Snake Inputs
      //Player 1
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
        // Player 2
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
            gridPosition += movementDir*speed;
            gridMoveTimer = gridMoveTimerMax;
        
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
    private float GetAngleFromVector(Vector2 dir)
    {
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
  // Snake Shrink
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
            isDead = true;

            if (gridPosition == BpGridPosition && isDead == true)
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

    private void ScreenWrapHzt()
    {
        if (gridPosition.x > level.width)
        {
            gridPosition.x = -level.width;
        }
        else if (gridPosition.x < -level.width)
        {
            gridPosition.x = level.width;
        }
    }

    private void ScreenWrapVrt()
    {
        if ( gridPosition.y > level.height)
        {
            gridPosition.y = -level.height;
        }
       else if( gridPosition.y < - level.height)
       {
            gridPosition.y = level.height;
       }
    }


}

