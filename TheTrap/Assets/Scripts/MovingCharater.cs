using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


    public class MovingCharater : MonoBehaviour
    {
        public float speed;
        private Rigidbody2D rb;
        public float jumpForce;
        private bool isGrounded = true;
        public Animator animator;
        private bool isInvincible = false;
        private SpriteRenderer SpriteRenderer;
        public float InvincibilityDuration;
        public GameObject Player;
        private bool onSpike;
        private Collider2D playerCollider;

        //public Transform PlayerDesign;
        //public Transform UpSpike;
        //public float UpSpikeSpeed;
        //public GameObject[] UpSpikes;
        //private int FallenSpike = 0;

        private SpriteRenderer spriteRenderer;
        

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
            playerCollider = GetComponent<Collider2D>();
        }
        private void Update()
        {
            Vector2 intPos = new Vector2(0, 0);
            animator.SetBool("Movement", false);


            if (Input.GetKey(KeyCode.D))
            {
                intPos.x = +1;
                rotate(0);
                animator.SetBool("Movement", true);
            }
            if (Input.GetKey(KeyCode.A))
            {
                intPos.x = -1;
                rotate(180);
                animator.SetBool("Movement", true);
            }
            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                animator.SetBool("Grounded", false);
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
                animator.SetBool("Grounded", true);
            }
        }


        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = false;
            }
        }

    private void OnTriggerEnter2D(Collider2D invincibleTrigger)
    {
        if (invincibleTrigger.gameObject.CompareTag("Spikes") && !isInvincible){
            onSpike = true;
            StartCoroutine(BlinkingEffect(invincibleTrigger));
        }
    }

    private void OnTriggerExit2D(Collider2D invincibleTrigger)
    {
        if (invincibleTrigger.gameObject.CompareTag("Spikes")){
            onSpike= false;
        }
    }

    IEnumerator BlinkingEffect(Collider2D spikeCollider)
    {
        isInvincible = true;
        Physics2D.IgnoreLayerCollision(7,8, true);


        for (float i = 0; i<= InvincibilityDuration; i += 0.3f)
        {
            SpriteRenderer.enabled = !SpriteRenderer.enabled;
            yield return new WaitForSeconds(0.1f);

        }

        Physics2D.IgnoreLayerCollision(7,8, false);

        SpriteRenderer.enabled = true;
        isInvincible = false;
    }

}
