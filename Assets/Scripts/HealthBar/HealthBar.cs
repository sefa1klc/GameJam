using UnityEngine;
using UnityEngine.UI;

    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthbar;

        public void UpdateHealthBar(float maxHealth, float currentHealth)
        {
            _healthbar.fillAmount = currentHealth / maxHealth;
        }
    }
