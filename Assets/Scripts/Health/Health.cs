using System;
using Tunings;
using UI;
using UnityEngine;

namespace Health
{
    [RequireComponent(typeof(TuningReference))]
    public class Health : MonoBehaviour
    {

        private float maxHealth;
        private float currentHealth;

        public event Action<float> OnTakeDamage;
        public event Action OnDeath;

        private SliderBar healthBar;

        void Awake()
        {
            maxHealth = GetComponent<TuningReference>().Get<HasHealth>().MaxHealth();
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
