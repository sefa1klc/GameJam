using System;
using Character;
using UnityEngine;

namespace DefaultNamespace
{
    
    [RequireComponent(typeof(BoxCollider2D))]
    public class Spell : MonoBehaviour
    {
        public float speed = 10f;
        public SpellContainer _SpellContainer;

        private BoxCollider2D BoxCollider2D;
        private Rigidbody2D Rigidbody2D;

        private PlayerController player;

        private void Awake()
        {
            BoxCollider2D = GetComponent<BoxCollider2D>();
            BoxCollider2D.isTrigger = true;

            Rigidbody2D = GetComponent<Rigidbody2D>();
            
            Destroy(this.gameObject,_SpellContainer.lifeTime);

        }

        void Update()
        {
            // Objeyi ileri doğru hareket ettir
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                HealthComponent enemyHealth = other.GetComponent<HealthComponent>();
                enemyHealth.TakeDamage(_SpellContainer.damage);
                    
                Destroy(this.gameObject);
                
            }
        }
    }
}