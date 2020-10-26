using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandHealth :MonoBehaviour, BaseHealth
{
    public int m_CurrentHealth;
    public int m_maxHealth = 250;

    public event Action<GameObject> OnDie;
    public event Action<int> TakeDamageEvent;
    public event Action OnResetHealth;

    private void Awake()
    {
        m_CurrentHealth = m_maxHealth;
    }

    public void Die()
    {
        OnDie?.Invoke(gameObject);
        GameManager.Instance.LevelFailed();
        // Level is over OR watch and Ad.
    }

    public void ResetHealth()
    {
        m_CurrentHealth = m_maxHealth;
        OnResetHealth?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        TakeDamageEvent?.Invoke(damage);
        // Reduce the health of the island;
        m_CurrentHealth -= damage;
        if (m_CurrentHealth <= 0)
        {
            Die();
        }
    }

    public int GetMaxHealth()
    {
        return m_maxHealth;
    }
}
