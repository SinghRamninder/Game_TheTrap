using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public GameObject[] spikes;
    public float fallInterval = 1.0f;
    public float fallSpeed = 5.0f;


    private void OnTriggerEnter2D(Collider2D spikeTrigger)
    {
            if (spikeTrigger.gameObject.CompareTag("Player"))
            {
                StartCoroutine(FallSpikesOneByOne());
            }
    }

    IEnumerator FallSpikesOneByOne()
    {
        for (int i = 0; i < spikes.Length; i++)
        {
            
            Rigidbody2D rb = spikes[i].AddComponent<Rigidbody2D>();
            
            rb.velocity = Vector2.down * fallSpeed;
            
            yield return new WaitForSeconds(fallInterval);
        }
    }
}
