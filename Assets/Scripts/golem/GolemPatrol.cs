using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace.golem
{
    public class GolemPatrol : MonoBehaviour
    {
        public GameObject pointA;
        public GameObject pointB;
        private Rigidbody2D rb;
        private Animator anim;
        private Transform currentpoint;
        public float speed;

        private void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            currentpoint = pointB.transform;
            anim.SetBool("isRun", true);

        }

        private void Update()
        {
            Vector2 point = currentpoint.position - transform.position;
            if (currentpoint == pointB.transform)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
            }

            if (Vector2.Distance(transform.position, currentpoint.position) < 0.5f &&
                currentpoint == pointB.transform)
            {
                flip();
                currentpoint = pointA.transform;
            }else if (Vector2.Distance(transform.position, currentpoint.position) < 0.5f &&
                      currentpoint == pointA.transform)
            {
                flip();
                currentpoint = pointB.transform;
            }
        }

        public void flip()
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}