using UnityEngine;
using UnityEngine.UI;

public class FoodController : MonoBehaviour
{
     public BoxCollider2D foodGrid;
     private   float score;
     

   
   
   private void Start()
   {
       FoodSpawn();
       score = 0;
       
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
     if(other.tag == "Player")
     {
        FoodSpawn();
        
        AddScore();

        
     }
 }
  public static float GetScore()
 {
   return score;
 }
 public static float AddScore()
 {
   score += 10;
   return score;
 }
 
}


 