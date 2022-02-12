using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
 
 // Snake Movement
    private Vector2 _movementdir = Vector2.right;
    private List<Transform> _segments;
    public Transform segmentprefab;
    

   
  private void Start()
   {
       _segments = new List<Transform>();
       _segments.Add(this.transform);

   }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            _movementdir = Vector2.up;
        }
         else if(Input.GetKeyDown(KeyCode.S))
        {
            _movementdir = Vector2.down;
        }
         else if(Input.GetKeyDown(KeyCode.A))
        {
            _movementdir = Vector2.left;
        }
         else if(Input.GetKeyDown(KeyCode.D))
        {
            _movementdir = Vector2.right;
        }
    }
    private void FixedUpdate()
    {
        for (int i= _segments.Count-1; i>0; i--)
        {
               _segments[i].position = _segments[i-1].position;
        }
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x + _movementdir.x),
        Mathf.Round(this.transform.position.y + _movementdir.y),0.0f);

    }

    private void Grow()
    {
       Transform segment = Instantiate(this.segmentprefab);
       segment.position = _segments[_segments.Count-1].position;
       _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
 {
     if(other.tag == "Food")
     {
        Grow();
     }
 }
}
