using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{

    public float speed;
    public float leftLimit;
    public float rightLimit;
    private bool movingRight = true;
    public float totalTime;
    private float time;
    private bool isTriggered = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTriggered)
        {
            time = 1;
            isTriggered = true;
            StartCoroutine(vibandfall());
        }
    }

    private IEnumerator vibandfall()
    {
        while (time > 0 && time < totalTime)
        {
            if (movingRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;

                if (transform.position.x >= rightLimit)
                    movingRight = false;
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;

                if (transform.position.x <= leftLimit)
                    movingRight = true;
            }
            time += Time.deltaTime;
            yield return null;
        }

        if (totalTime - time <= 0.01f)
        {
            Rigidbody2D rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        }
    }
}
