using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCharater : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public float jumpForce;
    private bool isGrounded = true;
    //public Transform PlayerDesign;
    public Transform UpSpike;
    public float UpSpikeSpeed;
    public GameObject[] UpSpikes;
    private int FallenSpike = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector2 intPos = new Vector2(0, 0);
        

        if (Input.GetKey(KeyCode.D))
        {
            intPos.x = +1;
            rotate(0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            intPos.x = -1;
            rotate(180);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


        transform.position += (Vector3)intPos * speed * Time.deltaTime;
    }

    private void rotate(float angle)
    {
        transform.rotation = Quaternion.Euler(0, angle, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    //private void OnTriggerEnter2D(Collider2D trigger)
    //{
    //    if (trigger.CompareTag("collision"))
    //    {
    //        Vector3 SpikeintPos = UpSpike.position;
    //        SpikeintPos.y = -3.78f;
    //        Vector3 SpikefinPos = SpikeintPos;
    //        UpSpike.position = Vector3.Lerp(SpikeintPos, SpikefinPos, UpSpikeSpeed* Time.deltaTime);
    //    }
    //}

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        
    }


}
