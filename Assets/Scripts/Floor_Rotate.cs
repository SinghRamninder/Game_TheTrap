using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_Rotate : MonoBehaviour
{

    public float radius = 2.0f; 
    public float speed = 2.0f;
    private Vector2 center;

    private float angle = 0f;

    private void Start()
    {
        center = transform.position;
    }

    void Update()
    {
        
        angle += speed * Time.deltaTime;

        float x = center.x + Mathf.Cos(angle) * radius;
        float y = center.y + Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, y, transform.position.z);
    }
}

