using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Floor_LR : MonoBehaviour
{

    public float speed;
    public float leftLimit;
    public float rightLimit;

    private bool movingRight = true;

    void Update()
    {
        
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            if (transform.position.x >= rightLimit)
                movingRight = false;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            if (transform.position.x <= leftLimit)
                movingRight = true;
        }
    }
}
