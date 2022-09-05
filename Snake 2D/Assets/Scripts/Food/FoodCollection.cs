using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class FoodCollection : MonoBehaviour
{
    [SerializeField] GameObject GrowthFood;
    [SerializeField] GameObject ShrinkageFood;
   SnakeController snakeController;
   ScoreController scoreController;

   void Start()
   {
     
     snakeController = GetComponent<SnakeController>();
     scoreController = GetComponent<ScoreController>();
   }


   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            
            snakeController.Grow();
            scoreController.IncreaseScore();
           Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("Food_Spl"))
        {
            snakeController.Shrink();
            Destroy(collision.gameObject);
        }
    }
  
}