using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallen : MonoBehaviour
{
    public GameObject[] GameObject;
    public GameObject targetobject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MovingCharater grounded = targetobject.GetComponent<MovingCharater>();
            grounded.isGrounded = false;
            foreach (GameObject i in GameObject)
            {
                i.tag = "Untagged";
            }
        }


    }
}
