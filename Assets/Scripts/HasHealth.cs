using System;
using UnityEngine;

public class HasHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;

    private float currentHealth;

    public event Action<float> OnTakeDamage;
    public event Action OnDeath;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float dmg)
    {
        OnTakeDamage?.Invoke(dmg);
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
