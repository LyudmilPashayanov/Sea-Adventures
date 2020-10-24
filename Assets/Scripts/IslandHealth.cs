using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandHealth :MonoBehaviour, BaseHealth
{
    public event Action<GameObject> OnDie;
    public event Action<int> TakeDamageEvent;

    public void Die()
    {
        OnDie?.Invoke(gameObject);
        // Level is over OR watch and Ad.
    }

    public void ResetHealth()
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int damage)
    {
        TakeDamageEvent?.Invoke(damage);
        // Reduce the health of the island;
    }
}
