using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class FoodController : MonoBehaviour
{
     public BoxCollider2D foodGrid;
     public Text ScoreText;
     private  float score;
     

   
   
   private void Start()
   {
       FoodSpawn();
       score = 0;
       ScoreText.text = "Score: " + score;
       
    }
   private void FoodSpawn()
 {
    Bounds bounds = this.foodGrid.bounds;

    float x = Random.Range(bounds.min.x,bounds.max.x);
    float y = Random.Range(bounds.min.y,bounds.max.y);

    this.transform.position = new Vector3(Mathf.Round(x),Mathf.Round(y),0.0f);
 }

 private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FoodSpawn();

            score += 10f;

            ScoreText.text = "Score: " + score;
        }
    }


}


 