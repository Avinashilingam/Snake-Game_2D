using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
 [SerializeField] float lifetime;
       void Start()
    {
        Invoke("FoodDestroy", lifetime);
    }

  void FoodDestroy()
  {
    Destroy(gameObject);
  }
}
