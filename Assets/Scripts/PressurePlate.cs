using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D platelight;
    public int duration;
    public float blinktime;
    private bool blinking = true;
    private bool collided = false;
  

    void Start()
    {
        StartCoroutine(lightonoff());
    }

    void Update()
    {
        if (!blinking && !collided)
        {
            StartCoroutine(showagain());
        }
        
    }

    private IEnumerator lightonoff()
    {
        for (int i = 0; i < duration; i++)
        {
            if (!collided)
            {
                platelight.enabled = !platelight.enabled;
            }
            else
            {
                platelight.enabled = true;
            }

            yield return new WaitForSeconds(blinktime);
        }

        blinking = false;
        
    }

    private IEnumerator showagain()
    {
        blinking = true;
        yield return new WaitForSeconds(15);
        
        if (!collided)
        {
            StartCoroutine(lightonoff());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collided = true;
            Destroy(GetComponent<BoxCollider2D>());
            platelight.enabled = true;
            LVL3_RandomEvents.instance.RandomEvent();
        }
    }
}
