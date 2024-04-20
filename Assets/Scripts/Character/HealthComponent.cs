using System;
using UnityEngine;

namespace Character
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField]private float maxHealth = 50f;
        private float currentHealth;

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
                anim.SetTrigger("isDeath");
                //Destroy(this.gameObject);
            }
        }
    }
}