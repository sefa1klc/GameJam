using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.sound;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    public int health = 100;
    private float currentHealth;

    private void Awake()
    {
        currentHealth = health;
        _healthBar.UpdateHealthBar(health,currentHealth);
    }

    public void TakeDamage(int damage)
    {
        FindObjectOfType<SoundManager>().PlayAudioClip("playerdamage"); 
        currentHealth -= damage;
        _healthBar.UpdateHealthBar(health,currentHealth);
        if (currentHealth <= 0)
        {
            
            Die();
        }
    }

    void Die()
    {
        FindObjectOfType<SoundManager>().StopAudioClip("playerdie"); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}