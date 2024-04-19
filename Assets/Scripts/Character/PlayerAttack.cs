using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;

namespace Character
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private float attackCoolDown;
        [SerializeField] private Transform spellPoint;
        [SerializeField] private Spell[] _spell;
        
        private float CoolDownTimer = Mathf.Infinity;
        private Animator anim;  
        private PlayerController _playerController;
        
        public int selectedSpellIndex = 0; // Seçilen büyü endeksi

        private void Awake()
        {
            anim = GetComponent<Animator>();
            _playerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            // Büyü seçimi için input kontrolleri
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedSpellIndex = 0; // 0. indeksteki büyüyü seç
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedSpellIndex = 1; // 1. indeksteki büyüyü seç
            }

            
            if (Input.GetMouseButtonDown(0) && CoolDownTimer > attackCoolDown && _playerController.canAttack())
            {
                CastSpell();
                Attack();
            }

            CoolDownTimer += Time.deltaTime;
        }

        private void Attack()
        {
            anim.SetTrigger("attack");
            CoolDownTimer = 0;

        }
        
        void CastSpell()
        {
            // Büyü objesini instantiate et
            
            // GameObject spell = Instantiate(_spell, transform.position + transform.forward, transform.rotation);
            // Destroy(spell,2f);
            //
            // // Instantiate edilen objenin yönünü ayarla (karakterin yönüne göre)
            // spell.transform.forward = transform.forward;

            Instantiate(_spell[selectedSpellIndex], spellPoint.position, spellPoint.rotation);

        }
    }
}