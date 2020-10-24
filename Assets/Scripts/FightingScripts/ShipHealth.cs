using System;
using System.Collections.Generic;
using UnityEngine;

public interface BaseHealth
{
    event Action<GameObject> OnDie;
    event Action<int> TakeDamageEvent;
    void TakeDamage(int damage);
    void Die();
    void ResetHealth();

}

public class ShipHealth : MonoBehaviour, BaseHealth
{
    [SerializeField]
    private int m_maxHealth = 100;
    private int m_currentHealth;

    public event Action<int> TakeDamageEvent;
    public event Action<GameObject> OnDie;
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
            Destroy(projectile);
        }
    }

    public void TakeDamage(int damage)
    {
        TakeDamageEvent?.Invoke(damage); // delegate invokation
        m_currentHealth -= damage;
        if(m_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        OnDie?.Invoke(gameObject);
        Destroy(gameObject);
    }

    public void ResetHealth()
    {
        m_currentHealth = m_maxHealth;
    }
}
