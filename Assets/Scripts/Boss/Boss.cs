using System;
using DefaultNamespace.sound;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace.Boss
{
    public class Boss : MonoBehaviour
    {
        public Transform player;
        private Animator anim;

        public bool isFlipped = false;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void LookAtPlayer()
        {
            Vector3 flipped = transform.localScale;
            flipped.z *= -1f;

            if (transform.position.x > player.position.x && isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
            }
            else if (transform.position.x < player.position.x && !isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.CompareTag("Player"))
            {
                FindObjectOfType<SoundManager>().PlayAudioClip("boss"); 
                FindObjectOfType<SoundManager>().StopAudioClip("Background"); 
                
                anim.SetTrigger("isattacking");
            }
        }
    }
}