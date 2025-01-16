using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Camera_movement : MonoBehaviour
{
    public Transform character;
    public float initPos;
    public float finPos;
    public float revPos;
    public float rotateSpeed;
    private Quaternion finRot = Quaternion.Euler(0,180,0);
    public GameObject[] gameObjects;


    void Update()
    {

        float target = Mathf.Clamp(character.position.x, initPos, finPos);
        transform.position = new Vector3(target, transform.position.y, transform.position.z);

        if (transform.position.x >= revPos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 10f);
            transform.rotation = Quaternion.Lerp(transform.rotation, finRot, Time.deltaTime * rotateSpeed);

            foreach (GameObject i in gameObjects)
            {
                Transform roofandfloor = i.transform;
                roofandfloor.position = new Vector3(roofandfloor.position.x, roofandfloor.position.y, 1f);
            }
            
        }
        
    }
}
