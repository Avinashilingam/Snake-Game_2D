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
        scoreText.text = "Score:"+ score;
    }

    [SerializeField] int growthFoodScore;

    public void IncreaseScore()
    {
        score += growthFoodScore;
        scoreText.text = "Score:" + score;
    }

    public void SetScoreForGainer(int score)
    {
        growthFoodScore = score;
    }
    public int GetScoreForGainer()
    {
        return growthFoodScore;
    }

    public int GetActiveScore()
    {
        return score;
    }
}
