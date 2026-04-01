using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    void Start()
    {
        float posx = Random.Range(startPos.x, endPos.x);

        transform.position = new Vector3 (posx, transform.position.y, transform.position.z);
    }

    
}
