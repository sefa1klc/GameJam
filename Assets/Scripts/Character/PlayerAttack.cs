using System;
using System.Collections;
using DefaultNamespace;
using DefaultNamespace.golem;
using DefaultNamespace.sound;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Character
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private float attackCoolDown;
        [SerializeField] private Transform spellPoint;
        [SerializeField] private Spell[] _spell;
        public GameObject newSkills;
        public Light2D asaLight;
        
        private float CoolDownTimer = Mathf.Infinity;
        private Animator anim;  
        private PlayerController _playerController;
        private bool newSkillsActivated = false;
        
        public int selectedSpellIndex = 0; // Seçilen büyü endeksi

        private void Awake()
        {
            asaLight = GetComponent<Light2D>();
            anim = GetComponent<Animator>();
            _playerController = GetComponent<PlayerController>();
            newSkills.SetActive(false);
        }

        private void Start()
        {
            FindObjectOfType<SoundManager>().PlayAudioClip("Background"); 
        }

        private void Update()
        {
            int enemyCount = FindObjectOfType<golemcounter>().GetEnemyCount();

            if (enemyCount == 5 && !newSkillsActivated)
            {
                if (asaLight != null)
                {
                    asaLight.color = Color.magenta; // Pembe renk
                }
                newSkills.SetActive(true);
                newSkillsActivated = true;
                Invoke("HideNewSkills", 5f); // 5 saniye sonra newSkills'i gizle
            }

            // Büyü seçimi için input kontrolleri
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedSpellIndex = 0; // 0. indeksteki büyüyü seç
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (enemyCount == 5)
                {
                    selectedSpellIndex = 1; // 1. indeksteki büyüyü seç
                }
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
            FindObjectOfType<SoundManager>().PlayAudioClip("spell"); 
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
        
        private void HideNewSkills()
        {
            newSkills.SetActive(false);
        }
    }
}