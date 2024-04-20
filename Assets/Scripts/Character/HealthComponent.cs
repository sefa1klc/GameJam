using System;
using DefaultNamespace.Boss;
using UnityEngine;

namespace Character
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField]private float maxHealth = 50f;
        private float currentHealth;
        [SerializeField]private lastWizard _lastWizard;

        private Animator anim;
            

        private void Awake()
        {
            currentHealth = maxHealth;
            anim = GetComponent<Animator>();
        }

        public void TakeDamage(float damage)
        {
            
            currentHealth -= damage;
            anim.SetTrigger("takingDamage");
            
            Debug.Log(currentHealth);
            
            if (currentHealth <= 0)
            {
                _lastWizard.animations();
                anim.SetTrigger("isDeath");
                Destroy(gameObject, 1f);
            }

        }

    }
}