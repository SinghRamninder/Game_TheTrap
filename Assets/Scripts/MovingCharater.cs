using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class MovingCharater : MonoBehaviour
    {
        public static MovingCharater Instance { get; private set; }

        public float speed;
        public float initSpeed;
        private Rigidbody2D rb;
        public float jumpForce;
        public bool isGrounded = true;
        public Animator animator;
        private bool isInvincible = false;
        private SpriteRenderer SpriteRenderer;
        public float InvincibilityDuration;
        public GameObject Player;
        private Collider2D playerCollider;
        private SpriteRenderer spriteRenderer;
        public Transform Block;
        
        

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
            playerCollider = GetComponent<Collider2D>();
            initSpeed = speed;
        }
        private void Update()
        {

            Vector2 intPos = new Vector2(0, 0);
            animator.SetBool("Movement", false);


            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                intPos.x = 1;
                rotate(0);
                animator.SetBool("Movement", true);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                intPos.x = -1;
                rotate(180);
                animator.SetBool("Movement", true);
            }
            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                AudioManager.Instance.jumpsound(0.3f);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                animator.SetBool("Grounded", false);
            }


            transform.position += (Vector3)intPos * speed * Time.deltaTime;

        if (speed < initSpeed)
        {
            StartCoroutine(increasespeed());
        }

        }


        private void rotate(float angle)
        {
            transform.rotation = Quaternion.Euler(0, angle, 0);

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("GroundBlock") || collision.gameObject.CompareTag("BreakingBlock_LVL1"))
            {
                isGrounded = true;
                animator.SetBool("Grounded", true);
            }
        if (collision.gameObject.CompareTag("GroundBlock"))
        {
            transform.parent = collision.transform;
        }
        if (collision.gameObject.CompareTag("BreakingBlock_LVL1"))
        {
            AudioManager.Instance.sfxplay(AudioManager.Instance.spikeHit, 1f);
            HealthManager.Instance.Damage(1f);
            speed = 4f;
            StartCoroutine(BlinkingEffect());
        }
    }


        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("GroundBlock") || collision.gameObject.CompareTag("BreakingBlock_LVL1"))
            {
                isGrounded = false;
            }
        if (collision.gameObject.CompareTag("GroundBlock"))
        {
            transform.parent = null;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D invincibleTrigger)
    {
        if (invincibleTrigger.gameObject.CompareTag("Spikes") && !isInvincible){

            AudioManager.Instance.sfxplay(AudioManager.Instance.spikeHit, 1f);
            HealthManager.Instance.Damage(0.5f);
            StartCoroutine(BlinkingEffect());
        }
        if (invincibleTrigger.gameObject.CompareTag("DownSpike") && !isInvincible){

            AudioManager.Instance.sfxplay(AudioManager.Instance.spikeHit, 1f);
            HealthManager.Instance.Damage(0.5f);
            speed = 5f;
            StartCoroutine(BlinkingEffect());
        }
        if (invincibleTrigger.gameObject.CompareTag("DamageColliderFull"))
        {
            AudioManager.Instance.sfxplay(AudioManager.Instance.LifeDecrease, 1f);
            HealthManager.Instance.Damage(3f);
        }
        if (invincibleTrigger.gameObject.CompareTag("SceneChange"))
        {
            SceneChange.Instance.Scenechange();
        }
    }

    IEnumerator increasespeed()
    {
        while (speed < initSpeed)
        {
            speed += 0.009f;
            yield return new WaitForSeconds(5f);
        };
    }

    IEnumerator BlinkingEffect()
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
