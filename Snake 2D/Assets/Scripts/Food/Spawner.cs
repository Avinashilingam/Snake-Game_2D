using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

   // Food spawning
    [SerializeField] GameObject growthFood;
    [SerializeField] GameObject shrinkageFood;
    [SerializeField]float foodspawnDelay;
    BoxCollider2D foodSpawnGrid;
    FoodCollection fc;
    float growthFoodTimer;
    float shrinkageFoodTimer = 15f;

    // Powerups spawning

    [SerializeField] GameObject[] powerups;
    [SerializeField] float powerUpSpawnDelay;
    float powerupTimer;
    int currentPowerup;

   
   
    
    void Start()
    {
         growthFoodTimer = 0f;
         shrinkageFoodTimer = 15f;
         foodSpawnGrid = GetComponent<BoxCollider2D>();
         fc = GetComponent<FoodCollection>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > growthFoodTimer && !fc)
        {
            SpawnFunct(growthFood);
            growthFoodTimer = Time.time + foodspawnDelay;
        }

        if(Time.time > shrinkageFoodTimer && !fc)
        {
            SpawnFunct(shrinkageFood);
            shrinkageFoodTimer = Time.time + Random.Range(5,10);
        }

        if(powerupTimer < Time.time)
        {
          currentPowerup = Random.Range(0, powerups.Length-1);
          SpawnFunct(powerups[currentPowerup]);
          powerupTimer = Time.time + powerUpSpawnDelay;
        }
    }
 public void SpawnFunct(GameObject spawnItem)
  {
    Bounds bounds = this.foodSpawnGrid.bounds;

    float x = Random.Range(bounds.min.x,bounds.max.x);
    float y = Random.Range(bounds.min.y,bounds.max.y);
    GameObject spawnPos = Instantiate(spawnItem);

    spawnPos.transform.position = new Vector2(Mathf.Round(x),Mathf.Round(y));
  }
 
 
}
