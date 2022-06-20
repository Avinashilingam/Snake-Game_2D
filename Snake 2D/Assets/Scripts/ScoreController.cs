using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
   

 private Text scoreText;

   
   private void Awake()
   {
      scoreText = transform.Find("ScoreText").GetComponent<Text>();
   }
   
    void Update()
    {
        scoreText.text = FoodController.GetScore().ToString();
        scoreText.text = FoodController.AddScore().ToString();
    }
}
