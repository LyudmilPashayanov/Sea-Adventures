using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHealth : MonoBehaviour, BaseHealth
{
    [SerializeField]
    private int m_maxHealth = 100;
    private int m_currentHealth;

    public event Action<int> TakeDamageEvent;
    public event Action<GameObject> OnDie;
    public event Action OnResetHealth;
    private void Awake()
    {
        m_currentHealth = m_maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        var projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            TakeDamage(projectile.m_Damage);
            Destroy(projectile.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        TakeDamageEvent?.Invoke(damage); // delegate invokation
        m_currentHealth -= damage;
        if (m_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        OnDie?.Invoke(gameObject);
        GameManager.Instance.LevelFailed();
    }

    public int GetMaxHealth()
    {
        return m_maxHealth;
    }

    public void ResetHealth()
    {
        m_currentHealth = m_maxHealth;
        OnResetHealth?.Invoke();
    }
}
