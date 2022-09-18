using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float powerupTime;
    int score;
    float speed;
    ScoreController scoreController;
    SnakeController snakeController;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreController = GetComponent<ScoreController>();
        score = scoreController.GetScoreForGrowthFood();
        snakeController = GetComponent<SnakeController>();
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
       
           if(collision.gameObject.tag=="Powerup")
            {
                scoreController.SetScoreForGrowthFood(score*2);
                Invoke("ResetScore", powerupTime);
                Destroy(collision.gameObject);
            }
           else if(collision.gameObject.tag == "Powerup_2")
            {
                speed = snakeController.GetSpeed();
                snakeController.SetSpeed(speed*5f);
                Invoke("ResetSpeed",powerupTime);
                Destroy(collision.gameObject);
                
            }
            else if(collision.gameObject.tag == "Powerup_3")
            {
               snakeController.SetISDead(false);
               Invoke("SetIsDead",powerupTime);
               Destroy(collision.gameObject);
            }
    }

   void ResetSpeed()
   {
        snakeController.SetSpeed(speed);
   }
    void ResetScore()
    {
        scoreController.SetScoreForGrowthFood(score);
    }
     void SetIsDead()
    {
        snakeController.SetISDead(true);
    }
}   
