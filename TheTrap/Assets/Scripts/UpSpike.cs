using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpSpike : MonoBehaviour
{
    public float speed = 2f; 
    private bool isMoving = false;
    public float Position;

    private void OnTriggerEnter2D(Collider2D UpSpikeTrigger)
    {
        if (UpSpikeTrigger.gameObject.CompareTag("Player") && !isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveSpike(new Vector3(transform.position.x, Position, transform.position.z)));
        }
    }

    private IEnumerator MoveSpike(Vector3 targetPosition)
    {
        Vector3 startPosition = transform.position;

        
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        
        transform.position = targetPosition;

        isMoving = false;
    }
}
