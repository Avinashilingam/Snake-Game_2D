using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject GrowthFood;
    [SerializeField] GameObject ShrinkageFood;
    [SerializeField]float SpawnDelay;
    BoxCollider2D foodSpawnGrid;
   
    
    void Start()
    {
         FoodSpawn();
         foodSpawnGrid = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void FoodSpawn()
 {
    Bounds bounds = this.foodSpawnGrid.bounds;

    float x = Random.Range(bounds.min.x,bounds.max.x);
    float y = Random.Range(bounds.min.y,bounds.max.y);

    this.transform.position = new Vector2(Mathf.Round(x),Mathf.Round(y));
 }
}
