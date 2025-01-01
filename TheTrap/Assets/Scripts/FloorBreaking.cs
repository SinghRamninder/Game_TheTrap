using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBreaking : MonoBehaviour
{

    public Animator floorbreaking;

    private void OnTriggerEnter2D(Collider2D FloorBreaking)
    {
        if (FloorBreaking.gameObject.CompareTag("Player"))
        {
            floorbreaking.SetBool("Hit", true);
            Debug.Log("Working");
        }
    }
}
