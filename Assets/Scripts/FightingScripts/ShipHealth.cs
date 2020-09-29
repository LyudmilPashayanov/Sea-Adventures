using System;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    [SerializeField]
    private int m_maxHealth = 100;
    private int m_currentHealth;

    public event Action OnDie = delegate { };

    private void Awake()
    {
        m_currentHealth = m_maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var projectile = collision.collider.GetComponent<Projectile>();
        if (projectile != null)
            TakeDamage(projectile.m_Damage);
    }

    private void TakeDamage(int damage)
    {
        m_currentHealth -= damage;
        if(m_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDie();
       
        // Destroy(gameObject);
    }
}
