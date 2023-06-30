using System;
using UnityEngine;

public class HasHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 1;

    private int currentHealth;

    public event Action<int> OnTakeDamage;
    public event Action OnDeath;

    private HealthBar healthBar;

    void Awake()
    {
        currentHealth = maxHealth;

        healthBar = GetComponentInChildren<HealthBar>();
    }

    public void TakeDamage(int dmg)
    {
        OnTakeDamage?.Invoke(dmg);
        currentHealth -= dmg;

        if (healthBar)
        {
            healthBar.SetHealth(currentHealth / (float) maxHealth);
        }

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
