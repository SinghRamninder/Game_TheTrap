using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL3_PlayerMovement : MonoBehaviour
{
    public float speed;
    public float tileMoveDistance = 1.0f;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private bool canMove = true;
    private bool collisionignored = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x = 1;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x = -1;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.y = 1;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection.y = -1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canMove)
        {
            if (!collisionignored)
            {
                Physics2D.IgnoreLayerCollision(7, 8, true);
                StartCoroutine(collisionstop());
            }
            
            if (moveDirection != Vector2.zero)
            {
                StartCoroutine(MoveOneTile(moveDirection.normalized));
            }
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            Vector2 newPosition = rb.position + moveDirection * speed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }
    }

    private IEnumerator MoveOneTile(Vector2 direction)
    {
        canMove = false;
        Vector2 targetPosition = rb.position + direction * tileMoveDistance;

        
        float elapsedTime = 0f;
        float moveDuration = tileMoveDistance / speed;

        while (elapsedTime < moveDuration)
        {
            rb.MovePosition(Vector2.Lerp(rb.position, targetPosition, elapsedTime / moveDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rb.MovePosition(targetPosition);
        canMove = true;
    }

    private IEnumerator collisionstop()
    {
        collisionignored = true;
        yield return new WaitForSeconds(1.5f);
        Physics2D.IgnoreLayerCollision(7, 8, false);
        collisionignored = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plate"))
        {
            Debug.Log("Collision detected");
        }
    }
}
