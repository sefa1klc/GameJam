using System;
using UnityEngine;

namespace DefaultNamespace.golem
{
    public class Golem : MonoBehaviour
    {
        public ParticleSystem ParticleSystem;
        [SerializeField]private float maxHealth = 50f;
        private float currentHealth;

        private Animator anim;
        private int attackDamage = 25;
            

        private void Awake()
        {
            currentHealth = maxHealth;
            anim = GetComponent<Animator>();
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log(currentHealth);

            if (currentHealth <= 0)
            {
                PlayDeathEffects();
                Destroy(this.gameObject);
            }

        }
        
        private void PlayDeathEffects()
        {
                // Particle sistemi çalıştır
                ParticleSystem.Play();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
        }
    }
}