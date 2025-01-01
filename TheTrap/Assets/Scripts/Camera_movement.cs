using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movement : MonoBehaviour
{
    public Transform character;
    
    void Update()
    {

        float target = Mathf.Clamp(character.position.x, -6.87f, 3000f);
        transform.position = new Vector3(target, 0.63f, transform.position.z);
        
    }
}
