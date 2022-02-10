using UnityEngine;

public class SnakeController : MonoBehaviour
{
 
 // Snake Movement
    private Vector2 _movementdir = Vector2.right;

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
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x + _movementdir.x),
        Mathf.Round(this.transform.position.y + _movementdir.y),0.0f);
    }
}
