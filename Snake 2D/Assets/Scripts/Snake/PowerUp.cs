using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float powerupTime;
    int score;
    ScoreController scoreController;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreController = GetComponent<ScoreController>();
        score = scoreController.GetScoreForGrowthFood();
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
       
           if(collision.gameObject.tag=="Powerup")
            {
                scoreController.SetScoreForGrowthFood(score*2);
                Invoke("SetScore", powerupTime);
                Destroy(collision.gameObject);
            }
        
    }


    void SetScore()
    {
        scoreController.SetScoreForGrowthFood(score);
    }
}   
