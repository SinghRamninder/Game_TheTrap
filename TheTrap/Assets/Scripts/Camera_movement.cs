using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movement : MonoBehaviour
{
    public Transform character;
    
    void Update()
    {

        float target = Mathf.Clamp(character.position.x, 0f, 30f);
        transform.position = new Vector3(target, 0.63f, -10f);
        
    }
}
