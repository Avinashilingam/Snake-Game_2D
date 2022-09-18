using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    int score;
    private void Start()
    {
        score = 0;
        
    }

    [SerializeField] int growthFoodScore;

    public void IncreaseScore()
    {
        score += growthFoodScore;
        scoreText.text = "Score:" + score;
    }

    public void SetScoreForGrowthFood(int score)
    {
        growthFoodScore = score;
    }
    public int GetScoreForGrowthFood()
    {
        return growthFoodScore;
    }

    public int GetActiveScore()
    {
        return score;
    }
}
