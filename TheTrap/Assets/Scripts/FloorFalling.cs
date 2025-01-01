using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFalling : MonoBehaviour
{
    public float speed = 2f;
    private bool isMoving = false;

    private void OnTriggerEnter2D(Collider2D FloorBlock)
    {
        if (FloorBlock.gameObject.CompareTag("Player") && !isMoving)
        {
            isMoving = true;
            StartCoroutine(FallFloor(new Vector3(transform.position.x, -5.56f , transform.position.z)));
        }
    }

    private IEnumerator FallFloor(Vector3 targetPosition)
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
