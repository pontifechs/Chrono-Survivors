using System;
using UI;
using UnityEngine;

namespace Health
{
    public class HasHealth : MonoBehaviour
    {
        [SerializeField] float maxHealth = 1;

        private float currentHealth;

        public event Action<float> OnTakeDamage;
        public event Action OnDeath;

        private SliderBar healthBar;

        void Awake()
        {
            currentHealth = maxHealth;

            healthBar = GetComponentInChildren<SliderBar>();
        }

        public void TakeDamage(float dmg)
        {
            if (currentHealth <= 0)
            {
                return;
            }
            
            OnTakeDamage?.Invoke(dmg);
            currentHealth -= dmg;

            if (healthBar)
            {
                healthBar.SetHealth(currentHealth / maxHealth);
            }

            if (currentHealth <= 0)
            {
                OnDeath?.Invoke();
            }
        }
    }
}
