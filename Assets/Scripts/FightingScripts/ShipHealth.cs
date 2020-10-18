using System;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
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

    private void TakeDamage(int damage)
    {
        TakeDamageEvent(damage);
        m_currentHealth -= damage;
        if(m_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDie(gameObject);
        Destroy(gameObject);
    }
}
