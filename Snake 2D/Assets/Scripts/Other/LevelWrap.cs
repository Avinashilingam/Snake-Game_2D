using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelWrap : MonoBehaviour
{
    public float height;
    public float width;
    private void Start() {
        SetHeightandWidth();
    }
    private void Update() {
        SetHeightandWidth();
    } 

    private void SetHeightandWidth()
    {
        height  = Camera.main.ScreenToWorldPoint(new Vector3 (0f, Screen.height,0f)).y;
        Debug.Log("height: "+ height);
        width = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, 0f,0f)).x;
        Debug.Log("width: "+ width);
    }
}

