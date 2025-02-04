using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Camera_movement : MonoBehaviour
{
    public Transform character;
    public float initPos;
    public float finPos;
    public float revPos;
    public float rotateSpeed;
    public float shakestart;
    public float shakemagnitude;
    private bool end = true;
    private Quaternion finRot = Quaternion.Euler(0,180,0);
    public GameObject[] gameObjects;
    public GameObject lastSpike;
    public GameObject ground;
    public GameObject Player;
    public GameObject SpikeTrigger;

    private BoxCollider2D lastspikecollider;
    private BoxCollider2D[] groundColliders;
    private BoxCollider2D Playercollider;
    private BoxCollider2D SpikeTriggercollider;

    private void Start()
    {
        lastspikecollider = lastSpike.GetComponent<BoxCollider2D>();
        groundColliders = ground.GetComponents<BoxCollider2D>();
        Playercollider = Player.GetComponent<BoxCollider2D>();
        SpikeTriggercollider = SpikeTrigger.GetComponent<BoxCollider2D>();

    }


    void Update()
    {

        float target = Mathf.Clamp(character.position.x, initPos, finPos);
        Vector3 targetposition = new Vector3(target, transform.position.y, transform.position.z);

        if (!end)
        {
            Vector2 shakeoffset = Random.insideUnitCircle * shakemagnitude;
            transform.position = targetposition + new Vector3 (shakeoffset.x, 0 , 0);
            transform.position = new Vector3 (transform.position.x, shakeoffset.y + 0.42f, transform.position.z);
        }
        else
        {
            transform.position = targetposition;
        }



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

        if (SpikeTriggercollider != null)
        {
            if (SpikeTriggercollider.IsTouching(Playercollider))
            {
                end = false;
            }

            foreach (var groundCollider in groundColliders)
            {
                if (lastspikecollider.IsTouching(groundCollider))
                {
                    end = true;
                    break;
                }
            }
        }

        
        
    }
}
