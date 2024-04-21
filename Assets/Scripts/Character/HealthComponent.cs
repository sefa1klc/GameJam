using System;
using DefaultNamespace.Boss;
using DefaultNamespace.sound;
using UnityEngine;

namespace Character
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField]private float maxHealth = 50f;
        private float currentHealth;
        [SerializeField]private lastWizard _lastWizard;
        [SerializeField] private HealthBar _healthBar;

        private Animator anim;
            

        private void Awake()
        {
            currentHealth = maxHealth;
            _healthBar.UpdateHealthBar(maxHealth,currentHealth);
            anim = GetComponent<Animator>();
        }

        public void TakeDamage(float damage)
        {
            FindObjectOfType<SoundManager>().PlayAudioClip("bossdamage"); 
            currentHealth -= damage;
            _healthBar.UpdateHealthBar(maxHealth,currentHealth);
            anim.SetTrigger("takingDamage");
            
            Debug.Log(currentHealth);
            
            if (currentHealth <= 0)
            {
                _lastWizard.animations();
                FindObjectOfType<SoundManager>().PlayAudioClip("bossdie"); 
                FindObjectOfType<SoundManager>().PlayAudioClip("Background"); 
                anim.SetTrigger("isDeath");
                Destroy(gameObject, 1f);
            }

        }

    }
}