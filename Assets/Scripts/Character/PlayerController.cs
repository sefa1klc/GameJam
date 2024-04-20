using System;
using System.Collections;
using UnityEngine;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float jumpForce = 10f;
        private float moveInput;

        private Rigidbody2D rb;
        private bool isGrounded;
        private Collider2D coll;
        private Animator anim;

        public Vector3 direction;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            coll = GetComponent<Collider2D>();
        }

        void Update()
        {
            // Horizontal movement
            moveInput = Input.GetAxisRaw("Horizontal");
            if (moveInput != 0)
            {
                rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
                // Karakterin yönünü, hareket yönüne otomatik olarak döndürme
                direction = new Vector3(Mathf.Sign(moveInput), 1, 1);
                transform.localScale = direction;
                
            }
            
            // Jumping
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                //anim.SetBool("isJump",true);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isGrounded = false;
                anim.SetBool("isJump",!isGrounded);
            }

        }
        void FixedUpdate()
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            anim.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
            anim.SetFloat("yVelocity", rb.velocity.y);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            isGrounded = true;
            anim.SetBool("isJump",!isGrounded);
        }

        public bool canAttack()
        {
            return moveInput == 0 && isGrounded;
        }
    }
}