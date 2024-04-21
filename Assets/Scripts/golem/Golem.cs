using System;
using DefaultNamespace.sound;
using UnityEngine;

namespace DefaultNamespace.golem
{
    public class Golem : MonoBehaviour
    {
        public ParticleSystem ParticleSystem;
        [SerializeField]private float maxHealth = 50f;
        [SerializeField] private HealthBar _healthBar;
        private float currentHealth;

        private Animator anim;
        private int attackDamage = 25;

        private void Awake()
        {
            currentHealth = maxHealth;
            _healthBar.UpdateHealthBar(maxHealth,currentHealth);
            anim = GetComponent<Animator>();
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            _healthBar.UpdateHealthBar(maxHealth,currentHealth);
            if (currentHealth <= 0)
            {
                PlayDeathEffects();
                Destroy(this.gameObject);
            }

        }
        
        private void PlayDeathEffects()
        {
                FindObjectOfType<SoundManager>().PlayAudioClip("golem"); 
                // Particle sistemi çalıştır
                ParticleSystem.Play();
                FindObjectOfType<golemcounter>().IncreaseEnemyCount();
                
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