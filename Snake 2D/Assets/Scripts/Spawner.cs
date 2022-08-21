using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject GrowthFood;
    [SerializeField] GameObject ShrinkageFood;
    [SerializeField]float spawnDelay;
    BoxCollider2D foodSpawnGrid;
    FoodCollection fc;

    float gfTimer;
    float sfTimer = 15f;

   
   
    
    void Start()
    {
         gfTimer = 0f;
         sfTimer = 15f;
         foodSpawnGrid = GetComponent<BoxCollider2D>();
         fc = GetComponent<FoodCollection>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > gfTimer && !fc)
        {
            FoodSpawn(GrowthFood);
            gfTimer = Time.time + spawnDelay;
        }

        if(Time.time > sfTimer && !fc)
        {
            FoodSpawn(ShrinkageFood);
            sfTimer = Time.time + Random.Range(5,10);
        }
    }
 public void FoodSpawn(GameObject spawnItem)
  {
    Bounds bounds = this.foodSpawnGrid.bounds;

    float x = Random.Range(bounds.min.x,bounds.max.x);
    float y = Random.Range(bounds.min.y,bounds.max.y);
    GameObject spawnPos = Instantiate(spawnItem);

    spawnPos.transform.position = new Vector2(Mathf.Round(x),Mathf.Round(y));
  }
 
 
}
